using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class PlannerVM
    {
        public TransactionalAccountVM CurrentAccount { get; set; } = new();
        public YearlySummaryVM? YearlySummary { get; set; }
        public MonthlySummaryVM? CurrentMonthlySummary { get; set; }
        public int CurrentYear { get; set; } = DateTime.Now.Year;
        public int CurrentMonth { get; set; } = DateTime.Now.Month;
        public decimal Budget { get; set; }
        public decimal TotalAmount => GetTotalAmount();
        public decimal Saved => Budget - TotalAmount;

        private decimal GetTotalAmount()
        {
            decimal totalAmount = 0;

            if (CurrentMonthlySummary?.Expenses != null && CurrentMonthlySummary.Expenses.Count > 0)
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
