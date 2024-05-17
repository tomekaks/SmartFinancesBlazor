using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Commands;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Queries;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SavingsAccountsController : BaseController
    {
        private readonly IMediator _mediator;

        public SavingsAccountsController(IMediator mediator, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<SavingsAccountDto>> GetAsync()
        {
            var account = await _mediator.Send(new GetSavingsAccountQuery { UserId = CurrentUserId });
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateSavingsAccountDto accountDto)
        {
            await _mediator.Send(new CreateSavingsAccountCommand { AccountDto = accountDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateSavingsAccountDto accountDto)
        {
            await _mediator.Send(new UpdateSavingsAccountCommand { UpdateAccountDto = accountDto });
            return Ok();
        }
    }
}
