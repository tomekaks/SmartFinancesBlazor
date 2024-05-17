using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries
{
    public class GetTransactionalAccountByNumberQuery : IRequest<TransactionalAccountDto>
    {
        public string AccountNumber { get; set; }
    }
}
