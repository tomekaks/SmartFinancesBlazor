using FluentValidation;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Validators
{
    public class UpdateExpenseCommandValidator : AbstractValidator<UpdateExpenseCommand>
    {
        public UpdateExpenseCommandValidator()
        {
            RuleFor(q => q.ExpenseDto.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.ExpenseDto.ExpenseTypeDto)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
