using SmartFinancesBlazorUI.Models;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        List<AccountDto> GetAccounts();
    }
}
