using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Commands;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlySummaryController : BaseController
    {
        private readonly IMediator _mediator;

        public MonthlySummaryController(IHttpContextAccessor contextAccessor, IMediator mediator) : base(contextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlySummaryDto>> GetAsync(int id)
        {
            var monthlySummaryDto = await _mediator.Send(new GetMonthlySummaryRequest { MonthlySummaryId = id });
            return Ok(monthlySummaryDto);
        }

        [HttpGet("byyear/{id}")]
        [SwaggerOperation(OperationId = "MonthlySummaryGetByYear")]
        public async Task<ActionResult<List<MonthlySummaryDto>>> GetAllByYearAsync(int id)
        {
            var monthlySummariesDto = await _mediator.Send(new GetMonthlySummariesByYearRequest { YearlySummaryId = id });
            return Ok(monthlySummariesDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateMonthlySummaryDto createMonthlySummaryDto)
        {
            await _mediator.Send(new CreateMonthlySummaryCommand { MonthlySummaryDto = createMonthlySummaryDto });
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(UpdateMonthlySummaryDto updateMonthlySummaryDto)
        {
            await _mediator.Send(new UpdateMonthlySummaryCommand { MonthlySummaryDto = updateMonthlySummaryDto });
            return Ok();
        }
    }
}
