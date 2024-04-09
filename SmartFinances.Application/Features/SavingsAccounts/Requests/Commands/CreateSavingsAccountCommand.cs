using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Requests.Commands
{
    public class CreateSavingsAccountCommand : IRequest
    {
        public CreateSavingsAccountDto AccountDto { get; set; }
    }
}
