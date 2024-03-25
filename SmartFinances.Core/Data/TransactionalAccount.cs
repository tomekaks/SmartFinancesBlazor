namespace SmartFinances.Core.Data
{
    public class TransactionalAccount : AbstractAccount
    {
        public string Type { get; set; }
        public List<YearlySummary> YearlySummaries { get; set; }
        public List<RegularExpense> RegularExpenses { get; set; }
        public decimal Budget { get; set; }
    }
}
