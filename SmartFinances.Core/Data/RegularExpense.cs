namespace SmartFinances.Core.Data
{
    public class RegularExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
