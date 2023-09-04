using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.Accounts.Requests.Commands;
using SmartFinances.Application.Features.Accounts.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAsync(string id)
        {
            var account = await _mediator.Send(new GetAccountRequest { UserId = id });
            return Ok(account);
        }

        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<AccountDto>> GetByNumberAsync(string accountNumber)
        {
            var account = await _mediator.Send(new GetAccountByNumberRequest { AccountNumber = accountNumber });
            return Ok(account);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAccountDto accountDto)
        {
            await _mediator.Send(new UpdateAccountCommand { UpdateAccountDto = accountDto });
            return Ok();
        }
    }
}
