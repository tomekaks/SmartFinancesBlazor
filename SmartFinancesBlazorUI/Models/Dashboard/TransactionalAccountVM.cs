namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class TransactionalAccountVM
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Budget { get; set; }
        public string Type { get; set; }
    }
}
