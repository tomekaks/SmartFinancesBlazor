using SmartFinancesBlazorUI.Models.Accounts;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountsService
    {
        Task<bool> RequestNewAccountAsync(NewAccountVM newAccountVM);
        Task<List<AccountVM>> GetAllAccountsAsync();
        Task ChangeAccountAsync(string accountNumber);
    }
}
