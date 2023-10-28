using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Dashboard
{
    public class AddFundsVM
    {
        [Required]
        [Range(0,10000)]
        public decimal Amount { get; set; }
    }
}
