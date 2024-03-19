using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;
using SmartFinances.Application.Features.TransactionalAccounts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Commands
{
    public class UpdateTransactionalAccountCommandHandler : IRequestHandler<UpdateTransactionalAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public UpdateTransactionalAccountCommandHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task Handle(UpdateTransactionalAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTransactionalAccountCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var transactionalAccount = await _unitOfWork.TransactionalAccounts.GetByIdAsync(request.AccountDto.Id);

            if (transactionalAccount == null)
            {
                throw new NotFoundException("TransactionalAccount", request.AccountDto.Id);
            }

            transactionalAccount = _transactionalAccountFactory.MapToModel(request.AccountDto, transactionalAccount);

            _unitOfWork.TransactionalAccounts.Update(transactionalAccount);
            await _unitOfWork.SaveAsync();
        }
    }
}
