using FluentValidation;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;

namespace SmartFinances.Application.Features.AccountRequests.Validators
{
    internal class UpdateAccountRequestCommandValidator : AbstractValidator<UpdateAccountRequestCommand>
    {
        public UpdateAccountRequestCommandValidator()
        {
            RuleFor(q => q.AccountRequestDto.Status)
                .NotEmpty().WithMessage("Request needs to have a status assigned");

            RuleFor(q => q.AccountRequestDto.AdminId)
                .NotEmpty().WithMessage("Request needs to have an assigned AdminId");
        }
    }
}
