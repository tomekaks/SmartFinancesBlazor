using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionalAccountsController : BaseController
    {
        private readonly IMediator _mediator;
        public TransactionalAccountsController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionalAccountDto>> GetAsync(int id)
        {
            var account = await _mediator.Send(new GetTransactionalAccountQuery { AccountId = id });
            return Ok(account);
        }

        [HttpGet("mainaccount")]
        [SwaggerOperation(OperationId = "TransactionalAccountsGetMainAccount")]
        public async Task<ActionResult<TransactionalAccountDto>> GetMainAccountAsync()
        {
            var account = await _mediator.Send(new GetMainTransactionalAccountQuery { UserId = CurrentUserId });
            return Ok(account);
        }

        [HttpGet]
        [Route("GetByAccountNumber/{accountNumber}")]
        [SwaggerOperation(OperationId = "TransactionalAccountsGetByNumber")]
        public async Task<ActionResult<TransactionalAccountDto>> GetByNumberAsync(string accountNumber)
        {
            var account = await _mediator.Send(new GetTransactionalAccountByNumberQuery { AccountNumber = accountNumber });
            return Ok(account);
        }

        [HttpGet]
        [Route("CheckIfExists/{accountNumber}")]
        [SwaggerOperation(OperationId = "TransactionalAccountsCheckIfExists")]
        public async Task<ActionResult<TransactionalAccountDto>> CheckIfExistsAsync(string accountNumber)
        {
            var account = await _mediator.Send(new CheckIfTransactionalAccountExistsQuery { AccountNumber = accountNumber });

            if (account == null)
            {
                return NotFound($"Account with number {accountNumber} does not exist.");
            }

            return Ok(account);
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "TransactionalAccountsGetAll")]
        public async Task<ActionResult<List<TransactionalAccountDto>>> GetAllAsync()
        {
            var accounts = await _mediator.Send(new GetUsersTransactionalAccountsQuery { UserId = CurrentUserId });
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTransactionalAccountDto accountDto)
        {
            await _mediator.Send(new CreateTransactionalAccountCommand { AccountDto = accountDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateTransactionalAccountDto accountDto)
        {
            await _mediator.Send(new UpdateTransactionalAccountCommand { AccountDto = accountDto });
            return Ok();
        }
    }
}
