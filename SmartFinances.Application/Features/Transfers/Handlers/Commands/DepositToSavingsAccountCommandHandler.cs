using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Transfers.Requests.Commands;
using SmartFinances.Application.Features.Transfers.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Transfers.Handlers.Commands
{
    public class DepositToSavingsAccountCommandHandler : IRequestHandler<DepositToSavingsAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public DepositToSavingsAccountCommandHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task Handle(DepositToSavingsAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new SavingsAccountTransferValidator();
            var validationResult = validator.Validate(request.TransferDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var transfer = _transferFactory.MapFromDeposit(request.TransferDto);

            var savingsAccount = await _unitOfWork.SavingsAccounts.GetAsync(q => q.Number == request.TransferDto.SavingsAccountNumber);
            var transactionalAccount = await _unitOfWork.TransactionalAccounts.GetAsync(q => q.Number == request.TransferDto.TransactionalAccountNumber);

            if (transactionalAccount == null || savingsAccount == null)
            {
                throw new Exception("One of the accounts was not found.");
            }

            if (transactionalAccount.Balance >= request.TransferDto.Amount)
            {
                savingsAccount.Balance += request.TransferDto.Amount;
                transactionalAccount.Balance -= request.TransferDto.Amount;

                await _unitOfWork.Transfers.AddAsync(transfer);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
