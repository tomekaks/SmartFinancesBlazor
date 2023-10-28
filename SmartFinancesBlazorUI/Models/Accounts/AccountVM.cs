namespace SmartFinancesBlazorUI.Models.Accounts
{
    public class AccountVM
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public decimal Budget { get; set; }
        public AccountType Type { get; set; }
    }
}
