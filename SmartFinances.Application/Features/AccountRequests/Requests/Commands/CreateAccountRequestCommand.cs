using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Requests.Commands
{
    public class CreateAccountRequestCommand : IRequest
    {
        public CreateAccountRequestDto AccountRequestDto { get; set; }
    }
}
