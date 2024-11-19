using SmartFinancesBlazorUI.Models.Transfers;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<TransfersOverviewVM> GenerateTransfersOverviewVM(string currentAccountNumber, int pageNumber = 1);
        Task<bool> CreateTransferAsync(NewTransferVM transferVM);
        Task<bool> DepositOnSavingsAccountAsync(decimal amount);
        Task<bool> WithdrawFromSavingsAccountAsync(decimal amount);
    }
}
