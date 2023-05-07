using MediatR;
using SmartFinances.Application.CQRS.Contact.Requests.Queries;
using SmartFinances.Application.Dto.ContactDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Contact.Handlers.Queries
{
    public class GetContactListRequestHandler : IRequestHandler<GetContactListRequest, List<ContactDto>>
    {
        private readonly IContactFactory _contactFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetContactListRequestHandler(IContactFactory contactFactory, IUnitOfWork unitOfWork)
        {
            _contactFactory = contactFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ContactDto>> Handle(GetContactListRequest request, CancellationToken cancellationToken)
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync(q => q.UserId == request.UserId);
            return _contactFactory.CreateContactDtoList(contacts.ToList());
        }
    }
}
