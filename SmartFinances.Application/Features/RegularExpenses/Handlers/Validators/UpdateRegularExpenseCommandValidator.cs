using FluentValidation;
using SmartFinances.Application.Features.RegularExpenses.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Handlers.Validators
{
    public class UpdateRegularExpenseCommandValidator : AbstractValidator<UpdateRegularExpenseCommand>
    {
        public UpdateRegularExpenseCommandValidator()
        {
            RuleFor(q => q.RegularExpenseDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.RegularExpenseDto.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.RegularExpenseDto.Type)
                .IsInEnum();
        }
    }
}
