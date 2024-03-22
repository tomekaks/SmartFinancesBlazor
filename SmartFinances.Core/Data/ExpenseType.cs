namespace SmartFinances.Core.Data
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<RegularExpense> RegularExpenses { get; set; }
    }
}
