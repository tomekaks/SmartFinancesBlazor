using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class DashboardVM
    {
        public AccountVM CurrentAccount { get; set; } = new AccountVM();
    }
}
