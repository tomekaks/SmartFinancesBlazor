using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Transfers.Handlers.Validators;
using SmartFinances.Application.Features.Transfers.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Transfers.Handlers.Commands
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public CreateTransferCommandHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTransferCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var transfer = _transferFactory.CreateTransfer(request.TransferDto);

            var receiverAccount = await _unitOfWork.Accounts.GetAsync(q => q.Number == transfer.ReceiverAccountNumber);
            var senderAccount = await _unitOfWork.Accounts.GetByIdAsync(transfer.AccountId);

            if (receiverAccount != null && senderAccount.Balance >= request.TransferDto.Amount)
            {
                receiverAccount.Balance += request.TransferDto.Amount;

                senderAccount.Balance -= request.TransferDto.Amount;

                await _unitOfWork.Transfers.AddAsync(transfer);
                await _unitOfWork.SaveAsync();
            }

            return;
        }
    }
}
