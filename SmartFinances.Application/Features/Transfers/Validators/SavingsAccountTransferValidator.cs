using FluentValidation;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Handlers.Commands;
using SmartFinances.Application.Features.Transfers.Requests.Commands;

namespace SmartFinances.Application.Features.Transfers.Validators
{
    internal class SavingsAccountTransferValidator : AbstractValidator<SavingsAccountTransferDto>
    {
        public SavingsAccountTransferValidator()
        {
            RuleFor(q => q.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.TransactionalAccountName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.TransactionalAccountName)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.SavingsAccountName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.SavingsAccountName)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(250).WithMessage("{PropertyName} can't be longer than 250 characters");
        }
    }
}
