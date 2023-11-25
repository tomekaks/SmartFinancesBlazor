using FluentValidation;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;

namespace SmartFinances.Application.Features.YearlySummaries.Validators
{
    public class UpdateYearlySummaryCommandValidator : AbstractValidator<UpdateYearlySummaryCommand>
    {
        private int _currentYear => DateTime.Now.Year;
        public UpdateYearlySummaryCommandValidator()
        {
            RuleFor(q => q.YearlySummaryDto.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
