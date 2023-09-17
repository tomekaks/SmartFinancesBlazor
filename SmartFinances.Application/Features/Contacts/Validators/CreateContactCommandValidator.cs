using FluentValidation;
using SmartFinances.Application.Features.Contacts.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Contacts.Validators
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(q => q.ContactDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.ContactDto.AccountNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(12).WithMessage("{PropertyName} has to be 12 characters long");
        }
    }
}
