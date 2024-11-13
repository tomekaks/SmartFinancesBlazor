using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SmartFinancesBlazorUI.Models.Contacts
{
    public class ContactVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Account number")]
        public string AccountNumber { get; set; } = string.Empty;
    }
}
