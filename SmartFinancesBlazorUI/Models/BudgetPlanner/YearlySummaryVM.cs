namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class YearlySummaryVM
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public List<MonthlySummaryVM> MonthlySummaries { get; set; } = new();
        public int AccountId { get; set; }
    }
}
