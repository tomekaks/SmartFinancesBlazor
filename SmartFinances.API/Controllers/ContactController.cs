using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Contacts.Dtos;
using SmartFinances.Application.Features.Contacts.Requests.Commands;
using SmartFinances.Application.Features.Contacts.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<ContactDto>>> GetAll(string userId)
        {
            var contacts = await _mediator.Send(new GetContactListRequest { UserId = userId });
            return Ok(contacts);
        }

        [HttpGet("get")]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            var contact = await _mediator.Send(new GetContactRequest { Id = id });
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContactDto contactDto)
        {
            await _mediator.Send(new CreateContactCommand { ContactDto = contactDto });
            return Ok();
        }

        [HttpPut]
        public void Update([FromBody] ContactDto contactDto)
        {
            _mediator.Send(new UpdateContactCommand { ContactDto = contactDto });
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _mediator.Send(new DeleteContactCommand { Id = id });
        }
    }
}
