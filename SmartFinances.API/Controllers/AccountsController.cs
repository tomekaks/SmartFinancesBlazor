using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.Accounts.Requests.Commands;
using SmartFinances.Application.Features.Accounts.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAsync(int id)
        {
            var account = await _mediator.Send(new GetAccountRequest { AccountId = id });
            return Ok(account);
        }

        [HttpGet("mainaccount")]
        [SwaggerOperation(OperationId = "AccountsGetMainAccount")]
        public async Task<ActionResult<AccountDto>> GetMainAccountAsync()
        {
            var account = await _mediator.Send(new GetMainAccountRequest { UserId = CurrentUserId });
            return Ok(account);
        }

        [HttpGet]
        [Route("GetByAccountNumber/{accountNumber}")]
        [SwaggerOperation(OperationId = "AccountsGetByNumber")]
        public async Task<ActionResult<AccountDto>> GetByNumberAsync(string accountNumber)
        {
            var account = await _mediator.Send(new GetAccountByNumberRequest { AccountNumber = accountNumber });
            return Ok(account);
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "AccountsGetAll")]
        public async Task<ActionResult<List<AccountDto>>> GetAllAsync()
        {
            var accounts = await _mediator.Send(new GetUsersAccountsRequest { UserId = CurrentUserId });
            return Ok(accounts);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAccountDto accountDto)
        {
            await _mediator.Send(new UpdateAccountCommand { UpdateAccountDto = accountDto });
            return Ok();
        }

        [HttpPost("{type}")]
        public async Task<IActionResult> CreateAsync(int type)
        {
            var createAccountDto = new CreateAccountDto()
            {
                Type = type,
                UserId = CurrentUserId
            };
            await _mediator.Send(new CreateAccountCommand { CreateAccountDto = createAccountDto });
            return Ok();
        }
    }
}
