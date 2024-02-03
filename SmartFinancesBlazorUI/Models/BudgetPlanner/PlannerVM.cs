namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class PlannerVM
    {
        public YearlySummaryVM? YearlySummary { get; set; }
        public MonthlySummaryVM? CurrentMonthlySummary { get; set; }
        public List<ExpenseTypeVM> ExpenseTypes { get; set; } = new();
        public decimal Budget { get; set; }
        public decimal TotalAmount { get => GetTotalAmount(); }
        public decimal Saved { get => Budget - TotalAmount; }

        private decimal GetTotalAmount()
        {
            decimal totalAmount = 0;

            if (CurrentMonthlySummary.Expenses != null && CurrentMonthlySummary.Expenses.Count > 0)
            {    
                foreach (var item in CurrentMonthlySummary.Expenses)
                {
                    totalAmount += item.Amount;
                }
            }
            return totalAmount;
        }
    }
}
