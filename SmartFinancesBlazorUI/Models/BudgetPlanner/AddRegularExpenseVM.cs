using SmartFinancesBlazorUI.Models.Enum;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class AddRegularExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeVM Type { get; set; }
    }
}
