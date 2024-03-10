using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class DepositVM
    {
        [Required]
        [Range(0, 100000)]
        public decimal Amount { get; set; }
        public AccountVM Account { get; set; }
        public AccountVM SavingsAccount { get; set; }
    }
}
