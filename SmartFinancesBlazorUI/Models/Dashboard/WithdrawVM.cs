using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class WithdrawVM
    {
        [Required]
        [Range(0, 100000)]
        public decimal Amount { get; set; }
        public TransactionalAccountVM TransactionalAccount { get; set; }
        public SavingsAccountVM SavingsAccount { get; set; }
    }
}
