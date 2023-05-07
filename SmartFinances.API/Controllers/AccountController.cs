using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using System.Security.Principal;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<ActionResult<AccountDto>> Get(string id)
        {
            var account = await _mediator.Send(new GetAccountRequest { UserId = id });
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountDto accountDto)
        {
            await _mediator.Send(new UpdateAccountCommand { UpdateAccountDto = accountDto });
            return Ok();
        }
    }
}
