using SmartFinancesBlazorUI.Models.Enum;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class AddRegularExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
    }
}
