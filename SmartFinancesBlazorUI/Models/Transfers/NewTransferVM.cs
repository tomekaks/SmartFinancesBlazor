using SmartFinancesBlazorUI.Models.Dashboard;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class NewTransferVM
    {
        [Required]
        [Display(Name = "Receiver name")]
        public string ReceiverName { get; set; }
        [Required]
        [Display(Name = "Receiver account number")]
        public string ReceiverAccountNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public TransactionalAccountVM CurrentAccountVM { get; set; }
    }
}
