using FluentValidation;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Validators
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(q => q.UpdateAccountDto.Balance)
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.UpdateAccountDto.Budget)
                .GreaterThanOrEqualTo(0);

        }
    }
}
