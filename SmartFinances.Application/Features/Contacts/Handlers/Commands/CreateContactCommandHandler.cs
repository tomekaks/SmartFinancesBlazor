using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Contacts.Requests.Commands;
using SmartFinances.Application.Features.Contacts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Contacts.Handlers.Commands
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
            contact.UserId = request.UserId;

            await _unitOfWork.Contacts.AddAsync(contact);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
