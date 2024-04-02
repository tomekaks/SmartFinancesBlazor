using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Commands
{
    public class CancelAccountRequestCommand : IRequest
    {
        public CancelAccountRequestDto AccountRequestDto { get; set; }
    }
}
