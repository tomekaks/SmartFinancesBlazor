using MediatR;
using SmartFinances.Application.Features.AccountTypes.Dtos;

namespace SmartFinances.Application.Features.AccountTypes.Requests.Queries
{
    public class GetAccountTypeQuery : IRequest<AccountTypeDto>
    {
        public int AccountTypeId { get; set; }
    }
}
