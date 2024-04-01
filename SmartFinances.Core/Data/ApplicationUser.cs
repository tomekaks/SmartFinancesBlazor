using Microsoft.AspNetCore.Identity;

namespace SmartFinances.Core.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Contact> Contacts { get; set; }
        public SavingsAccount SavingsAccount { get; set; }
        public List<TransactionalAccount> TransactionalAccounts { get; set; }
        public List<AccountRequest> AccountRequests { get; set; }
        public List<Notification> Notifications { get; set; }
        public bool IsSuspended { get; set; } = false;
        public string SuspensionReason { get; set; }
        public int NumberOfAccounts { get; set; }
    }
}
