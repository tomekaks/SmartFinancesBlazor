namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class MonthlySummaryVM
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public int YearlySummaryId { get; set; }
        public List<ExpenseVM> Expenses { get; set; } = new();
    }
}
