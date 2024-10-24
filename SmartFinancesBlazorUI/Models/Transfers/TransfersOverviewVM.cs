using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class TransfersOverviewVM
    {
        public List<IGrouping<DateOnly,TransferVM>> GroupedTransfers { get; set; }
        public List<TransferVM> Transfers { get; set; }
        public TransactionalAccountVM CurrentAccount { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 2;
    }
}
