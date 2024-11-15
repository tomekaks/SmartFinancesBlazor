using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountsService
    {
        Task CreateTransactionalAccountAsync(AccountTypeVM accountType, string requestingUserId);
        Task CreateSavingsAccountAcync(AccountTypeVM accountType, string requestingUserId);
        Task<List<TransactionalAccountVM>> GetUsersTransactionalAccountsAsync();
        Task<SavingsAccountVM> GetUsersSavingsAccountAsync();
        Task<TransactionalAccountVM> GetCurrentAccountAsync();
        Task<TransactionalAccountVM> GetTransactionalAccountByNumberAsync(string accountNumber);
        Task UpdateTransactionalAccountAsync(int accountId, decimal balance);
        //Task<TransactionalAccountVM> CheckIfTransactionalAccountExistsAsync(string accountNumber);
        Task<bool> CheckIfTransactionalAccountExistsAsync(string accountNumber);
    }
}
