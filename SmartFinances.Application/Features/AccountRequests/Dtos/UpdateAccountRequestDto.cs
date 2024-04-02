namespace SmartFinances.Application.Features.AccountRequests.Dtos
{
    public class UpdateAccountRequestDto
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public string Status { get; set; }
    }
}
