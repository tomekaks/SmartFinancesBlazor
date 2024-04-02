using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Queries
{
    public class GetAllAccountRequestsRequest : IRequest<List<AccountRequestDto>>
    {
    }
}
