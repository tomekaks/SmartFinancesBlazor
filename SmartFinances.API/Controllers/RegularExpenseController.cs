using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Requests.Commands;
using SmartFinances.Application.Features.RegularExpenses.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegularExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegularExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<RegularExpenseDto>>> GetAll(int accuntId)
        {
            var regularExpenses = await _mediator.Send(new GetRegularExpenseListRequest { AccountId = accuntId });
            return Ok(regularExpenses);
        }

        [HttpGet("get")]
        public async Task<ActionResult<RegularExpenseDto>> Get(int id)
        {
            var regularExpense = await _mediator.Send(new GetRegularExpenseRequest { Id = id });
            return Ok(regularExpense);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegularExpenseDto regularExpenseDto)
        {
            await _mediator.Send(new CreateRegularExpenseCommand { RegularExpenseDto = regularExpenseDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RegularExpenseDto regularExpenseDto)
        {
            await _mediator.Send(new UpdateRegularExpenseCommand { RegularExpenseDto = regularExpenseDto });
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteRegularExpenseCommand { Id = id });
            return Ok();
        }
    }
}
