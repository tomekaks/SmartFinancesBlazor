using MediatR;
using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Application.Features.Contacts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Contacts.Handlers.Queries
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDto>
    {
        private readonly IContactFactory _contactFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetContactQueryHandler(IContactFactory contactFactory, IUnitOfWork unitOfWork)
        {
            _contactFactory = contactFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.Id);

            if (contact == null)
            {
                return new ContactDto();
            }

            return _contactFactory.CreateContactDto(contact);
        }

    }
}
