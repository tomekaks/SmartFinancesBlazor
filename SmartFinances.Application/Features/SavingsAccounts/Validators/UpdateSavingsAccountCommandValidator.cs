using FluentValidation;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Commands;

namespace SmartFinances.Application.Features.SavingsAccounts.Validators
{
    internal class UpdateSavingsAccountCommandValidator : AbstractValidator<UpdateSavingsAccountCommand>
    {
        public UpdateSavingsAccountCommandValidator() 
        {
            RuleFor(q => q.UpdateAccountDto.Balance)
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.UpdateAccountDto.Goal)
                .GreaterThanOrEqualTo(0);
        }
    }
}
