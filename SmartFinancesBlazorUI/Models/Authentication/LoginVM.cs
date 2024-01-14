using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Authentication
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
