using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Commands
{
    public class CancelAccountRequestCommandHandler : IRequestHandler<CancelAccountRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelAccountRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CancelAccountRequestCommand request, CancellationToken cancellationToken)
        {
            var accountRequest = await _unitOfWork.AccountRequests.GetByIdAsync(request.AccountRequestDto.Id);

            if (accountRequest == null)
            {
                throw new NotFoundException("AccountRequest", request.AccountRequestDto.Id);
            }

            accountRequest.Status = Constants.STATUS_CANCELED;

            await _unitOfWork.SaveAsync();
        }
    }
}
