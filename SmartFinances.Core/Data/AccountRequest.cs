namespace SmartFinances.Core.Data
{
    public class AccountRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? DateApproved { get; set; }
        public string RejectedBy { get; set; }
        public DateTime? DateRejected { get; set; }
    }
}
