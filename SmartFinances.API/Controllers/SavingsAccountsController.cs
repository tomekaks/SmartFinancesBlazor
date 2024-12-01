using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Commands;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/savings-accounts")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateAsync(CreateSavingsAccountDto accountDto)
        {
            await _mediator.Send(new CreateSavingsAccountCommand { AccountDto = accountDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateSavingsGoalDto accountDto)
        {
            await _mediator.Send(new UpdateSavingsGoalCommand { UpdateAccountDto = accountDto });
            return Ok();
        }
    }
}
