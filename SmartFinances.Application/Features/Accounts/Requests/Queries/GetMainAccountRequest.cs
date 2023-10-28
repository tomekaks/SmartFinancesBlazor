using MediatR;
using SmartFinances.Application.Features.Accounts.Dtos;

namespace SmartFinances.Application.Features.Accounts.Requests.Queries
{
    public class GetMainAccountRequest : IRequest<AccountDto>
    {
        public string UserId { get; set; }
    }
}
