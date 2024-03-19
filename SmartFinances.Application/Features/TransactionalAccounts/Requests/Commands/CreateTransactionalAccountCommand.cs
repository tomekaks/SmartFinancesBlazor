using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands
{
    public class CreateTransactionalAccountCommand : IRequest
    {
        public CreateTransactionalAccountDto AccountDto { get; set; }
    }
}
