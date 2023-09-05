using FluentValidation;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Validators
{
    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(q => q.ExpenseDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.ExpenseDto.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.ExpenseDto.Type)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
