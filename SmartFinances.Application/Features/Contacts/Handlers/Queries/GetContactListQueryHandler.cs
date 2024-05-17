using MediatR;
using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Application.Features.Contacts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Contacts.Handlers.Queries
{
    public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, List<ContactDto>>
    {
        private readonly IContactFactory _contactFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetContactListQueryHandler(IContactFactory contactFactory, IUnitOfWork unitOfWork)
        {
            _contactFactory = contactFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ContactDto>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var contacts = (await _unitOfWork.Contacts.GetAllAsync(q => q.UserId == request.UserId)).ToList();

            if (contacts is null || contacts.Count < 1)
            {
                return new List<ContactDto>();
            }

            return _contactFactory.CreateContactDtoList(contacts.ToList());
        }
    }
}
