using FluentValidation;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Commands;

namespace SmartFinances.Application.Features.MonthlySummaries.Validators
{
    public class CreateMonthlySummaryCommandValidator : AbstractValidator<CreateMonthlySummaryCommand>
    {
        private int _currentYear => DateTime.Now.Year;
        public CreateMonthlySummaryCommandValidator()
        {
            RuleFor(q => q.MonthlySummaryDto).NotEmpty().WithMessage("{PropertyName} can't be empty");

            RuleFor(q => q.MonthlySummaryDto.Month)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .InclusiveBetween(1, 12).WithMessage("Month can't be smaller than 1 or bigger than 12");

            RuleFor(q => q.MonthlySummaryDto.Year)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .GreaterThanOrEqualTo(_currentYear).WithMessage("Year can't be smaller than current year")
                .LessThanOrEqualTo(_currentYear + 5).WithMessage("Year can't be bigger than 5 years ahead");

            RuleFor(q => q.MonthlySummaryDto.YearlySummaryId).NotEmpty().WithMessage("{PropertyName} can't be empty");
        }
    }
}
