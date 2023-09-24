using FluentValidation;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.ExpenseTypes.Validators
{
    public class CreateExpenseTypeCommandValidator : AbstractValidator<CreateExpenseTypeCommand>
    {
        public CreateExpenseTypeCommandValidator()
        {
            RuleFor(q => q.ExpenseTypeDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(255).WithMessage("{PropertyName} can't be longer than 255 characters");
        }
    }
}
