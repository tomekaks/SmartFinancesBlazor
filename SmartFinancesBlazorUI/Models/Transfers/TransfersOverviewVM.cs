using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class TransfersOverviewVM
    {
        public List<IGrouping<DateOnly, TransferVM>> GroupedTransfers { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
