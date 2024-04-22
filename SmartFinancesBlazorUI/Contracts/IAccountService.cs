using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountService
    {
        Task CreateTransactionalAccountAsync(AccountTypeVM accountType, string requestingUserId);
        Task CreateSavingsAccountAcync(AccountTypeVM accountType, string requestingUserId);
        Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync();
        Task<SavingsAccountVM> GetSavingsAccountAsync();
        Task<TransactionalAccountVM> GetTransactionalAccountByNumberAsync(string accountNumber);
        Task UpdateTransactionalAccountAsync(int accountId, decimal balance);
    }
}
