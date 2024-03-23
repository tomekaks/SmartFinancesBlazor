using FluentValidation;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;

namespace SmartFinances.Application.Features.YearlySummaries.Validators
{
    public class UpdateYearlySummaryCommandValidator : AbstractValidator<UpdateYearlySummaryCommand>
    {
        public UpdateYearlySummaryCommandValidator()
        {
            RuleFor(q => q.YearlySummaryDto.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.YearlySummaryDto.TransactionalAccountId)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
