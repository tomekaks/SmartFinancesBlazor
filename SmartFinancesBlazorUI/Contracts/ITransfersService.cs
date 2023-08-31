using SmartFinancesBlazorUI.Models.Transfers;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<List<TransferVM>> GetTransfers(string accountNumber);
        List<TransferVM> GetTransfers();
        Task<bool> CreateTransfer(NewTransferVM transferVM);

    }
}
