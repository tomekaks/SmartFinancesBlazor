using MediatR;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands
{
    public class CreateMainAccountCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
