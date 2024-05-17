using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Application.Features.AccountTypes.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTypesController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountTypesController(IHttpContextAccessor contextAccessor, IMediator mediator) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountTypeDto>>> GetAllAsync()
        {
            var accountTypes = await _mediator.Send(new GetAllAccountTypesQuery());
            return Ok(accountTypes);
        }
    }
}
