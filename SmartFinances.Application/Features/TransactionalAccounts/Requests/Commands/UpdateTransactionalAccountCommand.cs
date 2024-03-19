using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands
{
    public class UpdateTransactionalAccountCommand : IRequest
    {
        public UpdateTransactionalAccountDto AccountDto { get; set; }
    }
}
