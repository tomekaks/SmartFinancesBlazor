using SmartFinancesBlazorUI.Models.Transfers;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<List<TransferVM>> GetTransfersAsync();
        Task<bool> CreateTransferAsync(NewTransferVM transferVM);
        Task<string> GetCurrentAccountNumberAsync();

    }
}
