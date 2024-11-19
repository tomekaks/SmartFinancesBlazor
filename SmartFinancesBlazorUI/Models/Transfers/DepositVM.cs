using System.ComponentModel.DataAnnotations;
using SmartFinancesBlazorUI.Models.Dashboard;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class DepositVM
    {
        [Required]
        [Range(0, 100000)]
        public decimal Amount { get; set; }
        public TransactionalAccountVM TransactionalAccount { get; set; } = new();
        public SavingsAccountVM SavingsAccount { get; set; } = new();
    }
}
