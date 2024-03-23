using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardVM> LoadDashboardVM();
        Task<List<TransactionalAccountVM>> GetAllAccountsAsync();
        Task<bool> AddFundsAsync(AddFundsVM addFundsVM);
        Task ChangeAccountAsync(string accountNumber);
        Task<bool> RequestNewAccountAsync(int accountType);
        Task<WithdrawVM> LoadWithdrawVM();
        Task<bool> WithdrawFromSavingsAccountAsync(WithdrawVM withdrawVM);
        Task<DepositVM> LoadDepositVM();
        Task<bool> DepositOnSavingsAccountAsync(DepositVM depositVM);
    }
}
