using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Commands;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
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
            var accountRequests = await _mediator.Send(new GetAllAccountRequestsRequest());

            return Ok(accountRequests);
        }

        [HttpGet("UsersAccountRequests")]
        [SwaggerOperation(OperationId = "AccountRequestsGetByUser")]
        public async Task<ActionResult<List<AccountRequestDto>>> GetByUserAsync()
        {
            var accountRequests = await _mediator.Send(new GetUsersAccountRequestsRequest { UserId = CurrentUserId });

            return Ok(accountRequests);
        }

        [HttpGet("UsersAccountRequests/{status}")]
        [SwaggerOperation(OperationId = "AccountRequestsGetByUserAndStatus")]
        public async Task<ActionResult<List<AccountRequestDto>>> GetByUserAndStatusAsync(string status)
        {
            var accountRequests = await _mediator.Send(new GetUsersAccountRequestsRequest { UserId = CurrentUserId , Status = status });

            return Ok(accountRequests);
        }

        [HttpGet("AccountRequestsByStatus/{status}")]
        [SwaggerOperation(OperationId = "AccountRequestsGetByStatus")]
        public async Task<ActionResult<List<AccountRequestDto>>> GetByStatusAsync(string status)
        {
            var accountRequests = await _mediator.Send(new GetAccountRequestsByStatusRequest { Status = status });

            return Ok(accountRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountRequestDto>> GetAsync(int id)
        {
            try
            {
                var accountRequest = await _mediator.Send(new GetAccountRequestRequest { AccountRequestId = id });
                return Ok(accountRequest);
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }           
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
