using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Commands
{
    public class UpdateAccountRequestCommand : IRequest
    {
        public UpdateAccountRequestDto AccountRequestDto { get; set; }
    }
}
