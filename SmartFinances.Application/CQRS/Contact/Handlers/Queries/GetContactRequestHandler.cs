﻿using MediatR;
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
    public class GetContactRequestHandler : IRequestHandler<GetContactRequest, ContactDto>
    {
        private readonly IContactFactory _contactFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetContactRequestHandler(IContactFactory contactFactory, IUnitOfWork unitOfWork)
        {
            _contactFactory = contactFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactDto> Handle(GetContactRequest request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.Id);
            return _contactFactory.CreateContactDto(contact);
        }

    }
}
