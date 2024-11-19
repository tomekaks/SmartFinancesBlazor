using SmartFinancesBlazorUI.Models.Dashboard;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class NewTransferVM
    {
        [Required]
        [Display(Name = "Receiver name")]
        public string ReceiverName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Receiver account number")]
        public string ReceiverAccountNumber { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public TransactionalAccountVM CurrentAccountVM { get; set; } = new();
    }
}
