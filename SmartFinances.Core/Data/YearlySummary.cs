namespace SmartFinances.Core.Data
{
    public class YearlySummary
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public List<MonthlySummary> MonthlySummaries { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int TransactionalAccountId { get; set; }
        public TransactionalAccount TransactionalAccount { get; set; }
    }
}
