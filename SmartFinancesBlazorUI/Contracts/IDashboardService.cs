using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Admin;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync();
        Task<SavingsAccountVM> GetSavingsAccountAsync();
        Task<List<string>> GetUsersPendingAccountTypesAsync();
        Task<List<AccountTypeVM>> GetAccountTypesAsync();
        Task<TransactionalAccountVM> GetCurrentAccountAsync();

        Task<bool> AddFundsAsync(int accountId, decimal funds);
        Task ChangeAccountAsync(string accountNumber);

        Task SetSavingsGoalAsync(decimal goal);

        Task RequestNewAccountAsync(AccountTypeVM accountType);
    }
}
