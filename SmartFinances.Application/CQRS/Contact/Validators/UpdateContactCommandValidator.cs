using FluentValidation;
using SmartFinances.Application.CQRS.Contact.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Contact.Validators
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(q => q.ContactDto.Name)
                .NotEmpty().WithMessage("{PropertyName} are required")
                .MaximumLength(50).WithMessage("{PropertyName} can't be longer than 50 characters");

            RuleFor(q => q.ContactDto.AccountNumber)
                .NotEmpty().WithMessage("{PropertyName} are required")
                .Length(12).WithMessage("{PropertyName} has to be 12 characters long");
        }
    }
}
