using SmartFinancesBlazorUI.Models.AccountTypes;

namespace SmartFinancesBlazorUI.Models.Admin
{
    public class AccountRequestVM
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;  
        public string UserName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int AccountTypeId { get; set; }
        public AccountTypeVM AccountTypeVM { get; set; } = new();
        public string Status { get; set; } = string.Empty;
        public DateTime DateRequested { get; set; }
    }
}
