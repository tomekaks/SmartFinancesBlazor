using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class NewAccountVM
    {
        [Required(ErrorMessage = "Please select an accout type.")]
        public AccountType AccountType { get; set; }
        public List<AccountVM> Accounts { get; set; }
        public List<AccountType> AvailableAccountTypes { get; set; }
    }
}
