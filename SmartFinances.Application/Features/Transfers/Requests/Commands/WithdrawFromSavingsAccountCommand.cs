using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;

namespace SmartFinances.Application.Features.Transfers.Requests.Commands
{
    public class WithdrawFromSavingsAccountCommand : IRequest
    {
        public SavingsAccountTransferDto TransferDto { get; set; }
    }
}
