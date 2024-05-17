using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries
{
    public class GetUsersTransactionalAccountsQuery : IRequest<List<TransactionalAccountDto>>
    {
        public string UserId { get; set; }
    }
}
