using FluentValidation;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;

namespace SmartFinances.Application.Features.YearlySummaries.Validators
{
    public class CreateYearlySummaryCommandValidator : AbstractValidator<CreateYearlySummaryCommand>
    {
        public CreateYearlySummaryCommandValidator()
        {
            RuleFor(q => q.YearlySummaryDto.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
