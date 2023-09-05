namespace SmartFinances.Core.Data
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public bool IsRegular { get; set; }
    }
}
