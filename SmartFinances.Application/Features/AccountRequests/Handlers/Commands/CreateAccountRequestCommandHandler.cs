using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;
using SmartFinances.Application.Features.AccountRequests.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Commands
{
    public class CreateAccountRequestCommandHandler : IRequestHandler<CreateAccountRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public CreateAccountRequestCommandHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task Handle(CreateAccountRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAccountRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var accountRequest = _accountRequestFactory.CreateAccountRequest(request.AccountRequestDto);

            await _unitOfWork.AccountRequests.AddAsync(accountRequest);
            await _unitOfWork.SaveAsync();
        }
    }
}
