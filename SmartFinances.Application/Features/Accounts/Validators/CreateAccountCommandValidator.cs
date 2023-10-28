using FluentValidation;
using SmartFinances.Application.Features.Accounts.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Accounts.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(q => q.CreateAccountDto.Type)
                .GreaterThanOrEqualTo(1);

            RuleFor(q => q.CreateAccountDto.UserId)
                .NotEmpty().WithMessage("Account needs to have an assigned userId");

        }
    }
}
