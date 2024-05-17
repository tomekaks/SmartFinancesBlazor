using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Queries
{
    public class GetAccountRequestQuery : IRequest<AccountRequestDto>
    {
        public int AccountRequestId { get; set; }
    }
}
