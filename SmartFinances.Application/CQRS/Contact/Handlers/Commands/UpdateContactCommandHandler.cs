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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactFactory _contactFactory;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactCommandHandler(IContactFactory contactFactory, IUnitOfWork unitOfWork)
        {
            _contactFactory = contactFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateContactCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.ContactDto.Id);
            contact = _contactFactory.MapToModel(request.ContactDto, contact);

            _unitOfWork.Contacts.Update(contact);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
