using FluentValidation;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Commands;

namespace SmartFinances.Application.Features.SavingsAccounts.Validators
{
    internal class UpdateSavingsGoalCommandValidator : AbstractValidator<UpdateSavingsGoalCommand>
    {
        public UpdateSavingsGoalCommandValidator() 
        {
            RuleFor(q => q.UpdateAccountDto.Goal)
                .GreaterThanOrEqualTo(0);
        }
    }
}
