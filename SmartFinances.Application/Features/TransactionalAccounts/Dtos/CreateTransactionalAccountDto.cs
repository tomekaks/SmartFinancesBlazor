namespace SmartFinances.Application.Features.TransactionalAccounts.Dtos
{
    public class CreateTransactionalAccountDto
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
    }
}
