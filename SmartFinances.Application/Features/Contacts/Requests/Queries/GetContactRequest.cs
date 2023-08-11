using MediatR;
using SmartFinances.Application.Features.Contacts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Contacts.Requests.Queries
{
    public class GetContactRequest : IRequest<ContactDto>
    {
        public int Id { get; set; }
    }
}
