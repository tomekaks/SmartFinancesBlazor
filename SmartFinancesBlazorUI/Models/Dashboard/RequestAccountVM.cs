using SmartFinancesBlazorUI.Models.AccountTypes;
using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class RequestAccountVM
    {
        [Required(ErrorMessage = "Please select an accout type.")]
        public List<TransactionalAccountVM> Accounts { get; set; } = new();
        public List<AccountTypeVM> AccountTypes { get; set; } = new();
        public List<AccountTypeVM> AvailableAccountTypes { get; set; } = new();
        public List<string> PendingAccountTypes { get; set; } = new();
        public SavingsAccountVM? SavingsAccount { get; set; }
    }
}
