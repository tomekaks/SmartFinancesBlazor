using SmartFinancesBlazorUI.Models.AccountTypes;

namespace SmartFinancesBlazorUI.Models.Admin
{
    public class AccountRequestVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
        public AccountTypeVM AccountTypeVM { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
