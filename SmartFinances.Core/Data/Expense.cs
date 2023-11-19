namespace SmartFinances.Core.Data
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public int MonthlySummaryId { get; set; }
        public MonthlySummary MonthlySummary { get; set; }
    }
}
