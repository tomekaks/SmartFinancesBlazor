using MediatR;
using SmartFinances.Application.Features.Contacts.Dtos;

namespace SmartFinances.Application.Features.Contacts.Requests.Queries
{
    public class GetContactQuery : IRequest<ContactDto>
    {
        public int Id { get; set; }
    }
}
