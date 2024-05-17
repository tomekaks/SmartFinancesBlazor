using MediatR;
using SmartFinances.Application.Features.Contacts.Dtos;

namespace SmartFinances.Application.Features.Contacts.Requests.Queries
{
    public class GetContactListQuery : IRequest<List<ContactDto>>
    {
        public string UserId { get; set; }
    }
}
