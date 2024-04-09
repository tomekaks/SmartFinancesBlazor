using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Admin;
using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class RequestAccountVM
    {
        [Required(ErrorMessage = "Please select an accout type.")]
        public List<TransactionalAccountVM> Accounts { get; set; }
        public List<AccountTypeVM> AccountTypes { get; set; }
        public List<AccountTypeVM> AvailableAccountTypes { get; set; }
        public List<string> PendingAccountTypes { get; set; }
        public SavingsAccountVM? SavingsAccount { get; set; }
    }
}
