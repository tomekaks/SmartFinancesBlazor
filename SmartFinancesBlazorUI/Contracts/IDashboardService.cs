using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        List<AccountDto> GetAccounts();
    }
}
