using SmartFinancesBlazorUI.Models.AccountTypes;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class SavingsAccountVM
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Goal { get; set; }
        public int AccountTypeId { get; set; }
        public AccountTypeVM AccountTypeVM { get; set; }
    }
}
