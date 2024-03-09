using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class DashboardVM
    {
        public List<AccountVM> Accounts { get; set; }
        public AccountVM CurrentAccount { get; set; } = new AccountVM();
        public AccountVM? SavingsAccount { get; set; }
    }
}
