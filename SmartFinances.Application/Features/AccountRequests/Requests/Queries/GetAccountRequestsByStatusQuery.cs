using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Queries
{
    public class GetAccountRequestsByStatusQuery : IRequest<List<AccountRequestDto>> 
    {
        public string Status { get; set; }
    }
}
