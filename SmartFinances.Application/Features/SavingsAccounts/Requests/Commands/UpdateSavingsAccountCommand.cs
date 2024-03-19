using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Requests.Commands
{
    public class UpdateSavingsAccountCommand : IRequest
    {
        public UpdateSavingsAccountDto UpdateAccountDto { get; set; }
    }
}
