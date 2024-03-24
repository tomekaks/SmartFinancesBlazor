using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;
using SmartFinances.Application.Features.TransactionalAccounts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Commands
{
    public class CreateMainAccountCommandHandler : IRequestHandler<CreateMainAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public CreateMainAccountCommandHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task Handle(CreateMainAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMainAccountCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException("User", request.UserId);
            }

            var transactionalAccount = _transactionalAccountFactory.CreateMainAccount(request.UserId, user.UserName);

            await _unitOfWork.TransactionalAccounts.AddAsync(transactionalAccount);
            await _unitOfWork.SaveAsync();
        }
    }
}
