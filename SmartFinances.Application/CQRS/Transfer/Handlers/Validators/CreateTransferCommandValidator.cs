using FluentValidation;
using SmartFinances.Application.CQRS.Transfer.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Transfer.Handlers.Validators
{
    public class CreateTransferCommandValidator : AbstractValidator<CreateTransferCommand>
    {
        public CreateTransferCommandValidator()
        {
            RuleFor(q => q.TransferDto.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(q => q.TransferDto.ReceiverName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.TransferDto.ReceiverAccountNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(12).WithMessage("{PropertyName} has to be 12 characters long");

            RuleFor(q => q.TransferDto.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(250).WithMessage("{PropertyName} can't be longer than 250 characters");
        }
    }
}
