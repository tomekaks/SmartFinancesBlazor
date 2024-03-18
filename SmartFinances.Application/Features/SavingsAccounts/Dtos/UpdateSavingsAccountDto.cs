namespace SmartFinances.Application.Features.SavingsAccounts.Dtos
{
    public class UpdateSavingsAccountDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Goal { get; set; }
    }
}
