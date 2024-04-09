namespace SmartFinances.Application.Features.AccountRequests.Dtos
{
    public class CreateAccountRequestDto
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
    }
}
