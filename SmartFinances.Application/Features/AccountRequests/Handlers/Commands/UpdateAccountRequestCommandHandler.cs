using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;
using SmartFinances.Application.Features.AccountRequests.Validators;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Commands
{
    public class UpdateAccountRequestCommandHandler : IRequestHandler<UpdateAccountRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAccountRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAccountRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAccountRequestCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var accountRequest = await _unitOfWork.AccountRequests.GetByIdAsync(request.AccountRequestDto.Id);

            if (accountRequest == null)
            {
                throw new NotFoundException("AccountRequest", request.AccountRequestDto.Id);
            }

            accountRequest.Status = request.AccountRequestDto.Status;

            if (request.AccountRequestDto.Status == Constants.STATUS_APPROVED)
            {
                accountRequest.ApprovedBy = request.AccountRequestDto.AdminId;
                accountRequest.DateApproved = DateTime.UtcNow;
            }
            else if (request.AccountRequestDto.Status == Constants.STATUS_CANCELED)
            {
                accountRequest.RejectedBy = request.AccountRequestDto.AdminId;
                accountRequest.DateRejected = DateTime.UtcNow;
            }

            await _unitOfWork.SaveAsync();
        }
    }

}
