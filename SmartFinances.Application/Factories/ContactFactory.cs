using AutoMapper;
using SmartFinances.Application.Dto.ContactDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Factories
{
    public class ContactFactory : IContactFactory
    {
        private readonly IMapper _mapper;

        public ContactFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Contact CreateContact(ContactDto contactDto)
        {
            return _mapper.Map<Contact>(contactDto);
        }

        public ContactDto CreateContactDto(Contact contact)
        {
            return _mapper.Map<ContactDto>(contact);
        }

        public List<ContactDto> CreateContactDtoList(List<Contact> contacts)
        {
            return _mapper.Map<List<ContactDto>>(contacts);
        }

        public Contact MapToModel(ContactDto contactDto, Contact model)
        {
            return _mapper.Map(contactDto, model);
        }
    }
}
