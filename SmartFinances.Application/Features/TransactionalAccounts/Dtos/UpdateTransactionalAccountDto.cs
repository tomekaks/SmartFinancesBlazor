namespace SmartFinances.Application.Features.TransactionalAccounts.Dtos
{
    public class UpdateTransactionalAccountDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Budget { get; set; }
    }
}
