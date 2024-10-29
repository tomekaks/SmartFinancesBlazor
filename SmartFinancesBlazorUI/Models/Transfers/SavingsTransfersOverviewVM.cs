using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class SavingsTransfersOverviewVM
    {
        public List<IGrouping<DateOnly, TransferVM>> GroupedTransfers { get; set; }
        public SavingsAccountVM SavingsAccount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
