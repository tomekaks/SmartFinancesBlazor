using FluentValidation;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;

namespace SmartFinances.Application.Features.TransactionalAccounts.Validators
{
    internal class UpdateTransactionalAccountCommandValidator : AbstractValidator<UpdateTransactionalAccountCommand>
    {
        public UpdateTransactionalAccountCommandValidator()
        {
            RuleFor(q => q.AccountDto.Balance)
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.AccountDto.Budget)
                .GreaterThanOrEqualTo(0);
        }
    }
}
