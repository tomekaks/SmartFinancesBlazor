using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Requests.Commands;
using SmartFinances.Application.Features.RegularExpenses.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegularExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegularExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegularExpenseDto>>> GetAllAsync(int accuntId)
        {
            var regularExpenses = await _mediator.Send(new GetRegularExpenseListQuery { AccountId = accuntId });
            return Ok(regularExpenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegularExpenseDto>> GetAsync(int id)
        {
            var regularExpense = await _mediator.Send(new GetRegularExpenseQuery { Id = id });
            return Ok(regularExpense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegularExpenseDto regularExpenseDto)
        {
            await _mediator.Send(new CreateRegularExpenseCommand { RegularExpenseDto = regularExpenseDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EditRegularExpenseDto regularExpenseDto)
        {
            await _mediator.Send(new UpdateRegularExpenseCommand { RegularExpenseDto = regularExpenseDto });
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteRegularExpenseCommand { Id = id });
            return Ok();
        }
    }
}
