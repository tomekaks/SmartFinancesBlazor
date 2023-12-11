using FluentValidation;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Commands;

namespace SmartFinances.Application.Features.MonthlySummaries.Validators
{
    public class UpdateMonthlySummaryCommandValidator : AbstractValidator<UpdateMonthlySummaryCommand>
    {
        public UpdateMonthlySummaryCommandValidator()
        {
            RuleFor(q => q.MonthlySummaryDto)
                .NotEmpty().WithMessage("{PropertyName} can't be empty");

            RuleFor(q => q.MonthlySummaryDto.Budget)
                .GreaterThanOrEqualTo(0).WithMessage("Budget can't be less than 0");
        }
    }
}
