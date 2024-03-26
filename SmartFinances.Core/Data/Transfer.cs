namespace SmartFinances.Core.Data
{
    public class Transfer
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string SenderName { get; set; }
        public string SenderAccountNumber { get; set; }
        public string Title { get; set; }
    }
}
