using SmartFinancesBlazorUI.Models.Accounts;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        Task<AccountVM> GetMainAccountAsync();
        Task<bool> AddFundsAsync(AddFundsVM addFundsVM);
    }
}
