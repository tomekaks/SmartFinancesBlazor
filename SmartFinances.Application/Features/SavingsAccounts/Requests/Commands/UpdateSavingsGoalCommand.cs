using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Requests.Commands
{
    public class UpdateSavingsGoalCommand : IRequest
    {
        public UpdateSavingsGoalDto UpdateAccountDto { get; set; }
    }
}
