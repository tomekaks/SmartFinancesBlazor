using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountRequestController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountRequestController(IHttpContextAccessor contextAccessor, IMediator mediator) : base(contextAccessor)
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
    }
}
