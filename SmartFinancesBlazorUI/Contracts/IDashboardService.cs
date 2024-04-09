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

        Task<bool> AddFundsAsync(AddFundsVM addFundsVM);
        Task<bool> WithdrawFromSavingsAccountAsync(WithdrawVM withdrawVM);
        Task<bool> DepositOnSavingsAccountAsync(DepositVM depositVM);
        Task ChangeAccountAsync(string accountNumber);

        Task RequestNewAccountAsync(AccountTypeVM accountType);
    }
}
