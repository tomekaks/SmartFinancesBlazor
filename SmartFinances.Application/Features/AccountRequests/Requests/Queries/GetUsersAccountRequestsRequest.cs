using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Queries
{
    public class GetUsersAccountRequestsRequest : IRequest<List<AccountRequestDto>>
    {
        public string UserId { get; set; }
    }
}
