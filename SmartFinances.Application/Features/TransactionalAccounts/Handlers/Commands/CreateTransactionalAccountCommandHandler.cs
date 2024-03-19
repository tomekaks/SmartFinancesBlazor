using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;
using SmartFinances.Application.Features.TransactionalAccounts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Commands
{
    public class CreateTransactionalAccountCommandHandler : IRequestHandler<CreateTransactionalAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public CreateTransactionalAccountCommandHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task Handle(CreateTransactionalAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransactionalAccountCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var user = await _unitOfWork.Users.GetByIdAsync(request.AccountDto.UserId);

            if (user == null)
            {
                throw new NotFoundException("User", request.AccountDto.UserId);
            }

            var transactionalAccount = _transactionalAccountFactory.CreateTransactionalAccount(request.AccountDto, user.UserName);

            await _unitOfWork.TransactionalAccounts.AddAsync(transactionalAccount);
            await _unitOfWork.SaveAsync();
        }
    }
}
