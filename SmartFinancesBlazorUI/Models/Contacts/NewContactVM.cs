using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Contacts
{
    public class NewContactVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage ="Account number should be 12 characters long.")]
        [Display(Name = "Account number")]
        public string AccountNumber { get; set; } = string.Empty ;
    }
}
