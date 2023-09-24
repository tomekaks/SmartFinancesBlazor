using SmartFinancesBlazorUI.Models.Transfers;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<TransfersOverviewVM> GenerateTransfersOverviewVM();
        Task<bool> CreateTransferAsync(NewTransferVM transferVM);
    }
}
