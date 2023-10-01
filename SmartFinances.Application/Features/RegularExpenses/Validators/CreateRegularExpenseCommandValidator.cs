﻿using FluentValidation;
using SmartFinances.Application.Features.RegularExpenses.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Validators
{
    public class CreateRegularExpenseCommandValidator : AbstractValidator<CreateRegularExpenseCommand>
    {
        public CreateRegularExpenseCommandValidator()
        {
            RuleFor(q => q.RegularExpenseDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.RegularExpenseDto.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.RegularExpenseDto.ExpenseTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
