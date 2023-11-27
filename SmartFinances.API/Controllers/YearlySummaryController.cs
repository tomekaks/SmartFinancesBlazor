using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.YearlySummaries.Dtos;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;
using SmartFinances.Application.Features.YearlySummaries.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class YearlySummaryController : BaseController
    {
        private readonly IMediator _mediator;

        public YearlySummaryController(IHttpContextAccessor contextAccessor, IMediator mediator) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet("{accountid:int}/{year:int}")]
        public async Task<ActionResult<YearlySummaryDto>> GetAsync(int accountId, int year)
        {
            var yearlySummaryDto = await _mediator.Send(new GetYearlySummaryRequest { AccountId = accountId, Year = year });
            return Ok(yearlySummaryDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateYearlySummaryDto createYearlySummaryDto)
        {
            await _mediator.Send(new CreateYearlySummaryCommand { YearlySummaryDto = createYearlySummaryDto });
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(UpdateYearlySummaryDto updateYearlySummaryDto)
        {
            await _mediator.Send(new UpdateYearlySummaryCommand { YearlySummaryDto = updateYearlySummaryDto });
            return Ok();
        }
    }
}
