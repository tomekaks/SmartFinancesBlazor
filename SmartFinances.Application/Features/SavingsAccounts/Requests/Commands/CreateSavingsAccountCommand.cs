using MediatR;

namespace SmartFinances.Application.Features.SavingsAccounts.Requests.Commands
{
    public class CreateSavingsAccountCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
