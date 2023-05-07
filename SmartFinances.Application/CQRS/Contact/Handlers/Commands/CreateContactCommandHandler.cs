using MediatR;
using SmartFinances.Application.CQRS.Contact.Requests.Commands;
using SmartFinances.Application.CQRS.Contact.Validators;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Contact.Handlers.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactFactory _contactFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateContactCommandHandler(IContactFactory contactFactory, IUnitOfWork unitOfWork)
        {
            _contactFactory = contactFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var contact = _contactFactory.CreateContact(request.ContactDto);

            await _unitOfWork.Contacts.AddAsync(contact);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
