using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.Users.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TransactionalAccountDto> Accounts { get; set; }
        public SavingsAccountDto SavingsAccount { get; set; }
        public bool IsSuspended { get; set; }
        public string SuspensionReason { get; set; }
    }
}
