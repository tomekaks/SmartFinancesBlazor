using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IContactFactory
    {
        Contact CreateContact(ContactDto contactDto);
        ContactDto CreateContactDto(Contact contact);
        List<ContactDto> CreateContactDtoList(List<Contact> contacts);
        Contact MapToModel(ContactDto contactDto, Contact model);
    }
}
