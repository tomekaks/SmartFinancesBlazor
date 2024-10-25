using SmartFinances.Application.Dto;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ITransferFactory
    {
        Transfer CreateTransfer(CreateTransferDto createTransferDto);
        TransferDto CreateTransferDto(Transfer transfer);
        List<TransferDto> CreateTransferDtoList(List<Transfer> transfers);
        PaginatedList<TransferDto> CreatePaginatedListOfTransfers(
            List<Transfer> transfers, int pageNumber, int pageSize, int totalPages, int totalCount);
        Transfer MapToModel(UpdateTransferDto updateTransferDto, Transfer transfer);
        Transfer MapFromWithdrawal(SavingsAccountTransferDto savingsAccountTransferDto);
        Transfer MapFromDeposit(SavingsAccountTransferDto savingsAccountTransferDto);

    }
}
