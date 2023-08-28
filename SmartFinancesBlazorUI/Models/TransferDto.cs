namespace SmartFinancesBlazorUI.Models
{
    public class TransferDto
    {
        public string SenderName { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
    }
}
