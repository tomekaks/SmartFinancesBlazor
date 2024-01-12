using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardVM> LoadDashboardVM();
        Task<List<AccountVM>> GetUsersAccountsAsync();
        Task<AccountVM> GetMainAccountAsync();
        Task<AccountVM> LoadCurrentAccountAsync();
        Task<bool> AddFundsAsync(AddFundsVM addFundsVM);
        Task ChangeAccountAsync(string accountNumber);
    }
}
