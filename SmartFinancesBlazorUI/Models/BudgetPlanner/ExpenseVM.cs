namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class ExpenseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
        public bool IsRegular { get; set; }
    }
}
