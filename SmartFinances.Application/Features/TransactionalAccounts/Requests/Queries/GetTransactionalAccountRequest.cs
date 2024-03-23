using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries
{
    public class GetTransactionalAccountRequest : IRequest<TransactionalAccountDto>
    {
        public int AccountId { get; set; }
    }
}
