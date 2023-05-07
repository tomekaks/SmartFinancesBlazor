using FluentValidation;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(q => q.AccountName)
                    .NotEmpty().WithMessage("{PropertyName} is required")
                    .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");
        }
    }
}
