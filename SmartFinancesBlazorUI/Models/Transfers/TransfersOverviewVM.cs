namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class TransfersOverviewVM
    {
        public List<TransferVM> Transfers { get; set; } = new List<TransferVM>();
        public string AccountNumber { get; set; } = string.Empty;
    }
}
