namespace SmartFinances.Application.Features.AccountRequests.Dtos
{
    public class AccountRequestDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? DateApproved { get; set; }
    }
}
