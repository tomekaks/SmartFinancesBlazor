namespace SmartFinances.Core.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<YearlySummary> YearlySummaries { get; set; }
        public List<RegularExpense> RegularExpenses { get; set; }
        public decimal Budget { get; set; }
    }
}
