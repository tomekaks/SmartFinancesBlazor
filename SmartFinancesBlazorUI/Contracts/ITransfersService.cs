using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<TransfersOverviewVM> GenerateTransfersOverviewVM(int pageNumber = 1);
        Task<TransactionalAccountVM> GetCurrentAccountAsync();
        Task<bool> CreateTransferAsync(NewTransferVM transferVM);
        Task DepositOnSavingsAccountAsync(SavingsAccountTransferDto transferDto);
        Task WithdrawFromSavingsAccountAsync(SavingsAccountTransferDto transferDto);
        Task<bool> AddToContactsAsync(NewTransferVM transferVM);
    }
}
