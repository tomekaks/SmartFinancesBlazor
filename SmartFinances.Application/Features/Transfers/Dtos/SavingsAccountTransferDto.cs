namespace SmartFinances.Application.Features.Transfers.Dtos
{
    public class SavingsAccountTransferDto
    {
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public string TransactionalAccountName { get; set; }
        public string TransactionalAccountNumber { get; set; }
        public string SavingsAccountName { get; set; }
        public string SavingsAccountNumber { get; set; }
        public string Title { get; set; }
    }
}
