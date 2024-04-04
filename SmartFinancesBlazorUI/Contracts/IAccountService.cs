using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountService
    {
        Task CreateTransactionalAccountAsync(string accountType);
        Task CreateSavingsAccountAcync();
        Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync();
        Task<SavingsAccountVM> GetSavingsAccountAsync();
        Task<TransactionalAccountVM> GetTransactionalAccountByNumberAsync(string accountNumber);
        Task UpdateTransactionalAccountAsync(UpdateTransactionalAccountDto accountDto);
    }
}
