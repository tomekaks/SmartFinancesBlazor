namespace SmartFinances.Core.Data
{
    public class MonthlySummary
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public List<Expense> Expenses { get; set; }
        public int YearlySummaryId { get; set; }
        public YearlySummary YearlySummary { get; set; }
    }
}
