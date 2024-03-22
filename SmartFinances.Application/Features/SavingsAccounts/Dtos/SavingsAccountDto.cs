using SmartFinances.Application.Features.Transfers.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Dtos
{
    public class SavingsAccountDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public decimal Goal { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
