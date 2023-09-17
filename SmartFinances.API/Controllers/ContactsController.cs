using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Application.Features.Contacts.Requests.Commands;
using SmartFinances.Application.Features.Contacts.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : BaseController
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> GetAllAsync()
        {
            var contacts = await _mediator.Send(new GetContactListRequest { UserId = CurrentUserId });
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetAsync(int id)
        {
            var contact = await _mediator.Send(new GetContactRequest { Id = id });
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ContactDto contactDto)
        {
            await _mediator.Send(new CreateContactCommand { ContactDto = contactDto, UserId = CurrentUserId });
            return Ok();
        }

        [HttpPut]
        public async Task Update([FromBody] ContactDto contactDto)
        {
            contactDto.UserId = CurrentUserId;
            await _mediator.Send(new UpdateContactCommand { ContactDto = contactDto });
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteContactCommand { Id = id });
        }
    }
}
