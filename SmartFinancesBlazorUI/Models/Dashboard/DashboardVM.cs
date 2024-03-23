using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class DashboardVM
    {
        public List<TransactionalAccountVM> Accounts { get; set; }
        public TransactionalAccountVM CurrentAccount { get; set; } = new();
        public SavingsAccountVM? SavingsAccount { get; set; }
    }
}
