using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class TransfersOverviewVM
    {
        public List<TransferVM> Transfers { get; set; }
        public TransactionalAccountVM CurrentAccount { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
    }
}
