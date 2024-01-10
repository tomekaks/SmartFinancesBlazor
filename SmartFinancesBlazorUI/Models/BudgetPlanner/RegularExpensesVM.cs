namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class RegularExpensesVM
    {
        public List<RegularExpenseVM> RegularExpenses { get; set; } = new();
        public List<ExpenseTypeVM> ExpenseTypes { get; set; } = new();
    }
}
