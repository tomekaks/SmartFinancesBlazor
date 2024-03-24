using FluentValidation;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;

namespace SmartFinances.Application.Features.TransactionalAccounts.Validators
{
    internal class CreateMainAccountCommandValidator : AbstractValidator<CreateMainAccountCommand>
    {
        public CreateMainAccountCommandValidator()
        {
            RuleFor(q => q.UserId)
                .NotEmpty().WithMessage("Account needs to have an assigned userId");
        }
    }
}
