using FluentValidation;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;

namespace SmartFinances.Application.Features.YearlySummaries.Validators
{
    public class CreateYearlySummaryCommandValidator : AbstractValidator<CreateYearlySummaryCommand>
    {
        private int _currentYear => DateTime.Now.Year;
        public CreateYearlySummaryCommandValidator()
        {
            RuleFor(q => q.YearlySummaryDto.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.YearlySummaryDto.Year)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .GreaterThanOrEqualTo(_currentYear).WithMessage("Year can't be smaller than current year")
                .LessThanOrEqualTo(_currentYear + 5).WithMessage("Year can't be bigger than 5 years ahead");
        }
    }
}
