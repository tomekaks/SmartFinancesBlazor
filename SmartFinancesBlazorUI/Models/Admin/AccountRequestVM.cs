namespace SmartFinancesBlazorUI.Models.Admin
{
    public class AccountRequestVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
