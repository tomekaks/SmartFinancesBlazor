using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ITransferFactory
    {
        Transfer CreateTransfer(CreateTransferDto createTransferDto);
        TransferDto CreateTransferDto(Transfer transfer);
        List<TransferDto> CreateTransferDtoList(List<Transfer> transfers);
        Transfer MapToModel(UpdateTransferDto updateTransferDto, Transfer transfer);
        Transfer MapFromWithdrawal(SavingsAccountTransferDto savingsAccountTransferDto);
        Transfer MapFromDeposit(SavingsAccountTransferDto savingsAccountTransferDto);

    }
}
