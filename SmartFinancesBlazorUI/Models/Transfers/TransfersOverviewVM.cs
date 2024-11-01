using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class TransfersOverviewVM
    {
        public List<IGrouping<DateOnly,TransferVM>> GroupedTransfers { get; set; }
        public TransactionalAccountVM CurrentAccount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
