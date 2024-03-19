using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries
{
    public class GetMainTransactionalAccountRequest : IRequest<TransactionalAccountDto>
    {
        public string UserId { get; set; }
    }
}
