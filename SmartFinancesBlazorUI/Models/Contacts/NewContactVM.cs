using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Contacts
{
    public class NewContactVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Account number")]
        public string AccountNumber { get; set; }
    }
}
