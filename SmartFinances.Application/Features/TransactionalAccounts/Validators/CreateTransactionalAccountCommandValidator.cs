using FluentValidation;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;

namespace SmartFinances.Application.Features.TransactionalAccounts.Validators
{
    internal class CreateTransactionalAccountCommandValidator : AbstractValidator<CreateTransactionalAccountCommand>
    {
        public CreateTransactionalAccountCommandValidator()
        {
            RuleFor(q => q.AccountDto.Type)
                .NotEmpty().WithMessage("Account needs to have a type");

            RuleFor(q => q.AccountDto.UserId)
                .NotEmpty().WithMessage("Account needs to have an assigned userId");
        }
    }
}
