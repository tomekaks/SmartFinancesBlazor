using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Queries
{
    public class GetUsersAccountRequestsQuery : IRequest<List<AccountRequestDto>>
    {
        public string UserId { get; set; }
        public string Status { get; set; }
    }
}
