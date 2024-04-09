namespace SmartFinances.Core.Data
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TransactionalAccount> TransactionalAccounts { get; set; }
        public List<SavingsAccount> SavingsAccounts { get; set; }
        public List<AccountRequest> AccountRequests { get; set; }
    }
}
