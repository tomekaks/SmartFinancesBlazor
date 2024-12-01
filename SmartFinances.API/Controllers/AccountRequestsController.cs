using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/account-requests")]
    [ApiController]
    [Authorize]
    public class AccountRequestsController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountRequestsController(IHttpContextAccessor contextAccessor, IMediator mediator) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountRequestDto>>> GetAllAsync()
        {
            var accountRequests = await _mediator.Send(new GetAllAccountRequestsQuery());

            return Ok(accountRequests);
        }

        [HttpGet("by-user")]
        [SwaggerOperation(OperationId = "AccountRequestsGetByUser")]
        public async Task<ActionResult<List<AccountRequestDto>>> GetByUserAsync()
        {
            var accountRequests = await _mediator.Send(new GetUsersAccountRequestsQuery { UserId = CurrentUserId });

            return Ok(accountRequests);
        }

        [HttpGet("by-user-and-status/{status}")]
        [SwaggerOperation(OperationId = "AccountRequestsGetByUserAndStatus")]
        public async Task<ActionResult<List<AccountRequestDto>>> GetByUserAndStatusAsync(string status)
        {
            var accountRequests = await _mediator.Send(new GetUsersAccountRequestsQuery { UserId = CurrentUserId , Status = status });

            return Ok(accountRequests);
        }

        [HttpGet("by-status/{status}")]
        [SwaggerOperation(OperationId = "AccountRequestsGetByStatus")]
        public async Task<ActionResult<List<AccountRequestDto>>> GetByStatusAsync(string status)
        {
            var accountRequests = await _mediator.Send(new GetAccountRequestsByStatusQuery { Status = status });

            return Ok(accountRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountRequestDto>> GetAsync(int id)
        {
            var accountRequest = await _mediator.Send(new GetAccountRequestQuery { AccountRequestId = id });
            return Ok(accountRequest); 
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateAccountRequestDto accountRequestDto)
        {
            accountRequestDto.UserId = CurrentUserId;   
            await _mediator.Send(new CreateAccountRequestCommand { AccountRequestDto = accountRequestDto});
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(UpdateAccountRequestDto accountRequestDto)
        {
            accountRequestDto.AdminId = CurrentUserId;
            await _mediator.Send(new UpdateAccountRequestCommand { AccountRequestDto = accountRequestDto });
            return Ok();
        }
    }
}
