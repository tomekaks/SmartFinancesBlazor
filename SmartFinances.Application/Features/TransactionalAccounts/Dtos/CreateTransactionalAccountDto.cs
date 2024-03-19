namespace SmartFinances.Application.Features.TransactionalAccounts.Dtos
{
    public class CreateTransactionalAccountDto
    {
        public string UserId { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
    }
}
