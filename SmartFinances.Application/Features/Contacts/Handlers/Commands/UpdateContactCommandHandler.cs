using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Contacts.Requests.Commands;
using SmartFinances.Application.Features.Contacts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Contacts.Handlers.Commands
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

            if (contact != null)
            {
                contact = _contactFactory.MapToModel(request.ContactDto, contact);
                _unitOfWork.Contacts.Update(contact);
                await _unitOfWork.SaveAsync();
            }

            return;
        }
    }
}
