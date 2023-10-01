namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class RegularExpenseVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public ExpenseTypeVM ExpenseTypeVM { get; set; } = new ExpenseTypeVM();
        public int AccountId { get; set; }
    }
}
