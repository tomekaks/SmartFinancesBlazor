using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;

namespace SmartFinancesBlazorUI.Services
{
    public class DashboardService : IDashboardService
    {
        public List<AccountDto> GetAccounts()
        {
            return new List<AccountDto>();
        }
    }
}
