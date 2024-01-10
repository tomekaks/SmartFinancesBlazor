namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class ExpenseVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public ExpenseTypeVM ExpenseTypeVM { get; set; }
        public int AccountId { get; set; }
        public bool IsRegular { get; set; }
    }
}
