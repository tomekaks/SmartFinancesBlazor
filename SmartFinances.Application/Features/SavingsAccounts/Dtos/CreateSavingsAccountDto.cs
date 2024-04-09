using SmartFinances.Application.Features.AccountTypes.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Dtos
{
    public class CreateSavingsAccountDto
    {
        public string UserId { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
    }
}
