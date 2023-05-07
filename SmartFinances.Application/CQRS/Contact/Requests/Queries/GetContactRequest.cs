using MediatR;
using SmartFinances.Application.Dto.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Contact.Requests.Queries
{
    public class GetContactRequest : IRequest<ContactDto>
    {
        public int Id { get; set; }
    }
}
