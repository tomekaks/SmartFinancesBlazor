using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries
{
    public class CheckIfTransactionalAccountExistsQuery : IRequest<TransactionalAccountDto>
    {
        public string AccountNumber { get; set; }
    }
}
