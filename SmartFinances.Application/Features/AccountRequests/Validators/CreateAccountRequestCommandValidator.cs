using FluentValidation;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;

namespace SmartFinances.Application.Features.AccountRequests.Validators
{
    internal class CreateAccountRequestCommandValidator : AbstractValidator<CreateAccountRequestCommand>
    {
        public CreateAccountRequestCommandValidator()
        {
            RuleFor(q => q.AccountRequestDto.AccountType)
                .NotEmpty().WithMessage("Account needs to have a type");

            RuleFor(q => q.AccountRequestDto.UserId)
                .NotEmpty().WithMessage("Request needs to have an assigned userId");
        }
    }
}
