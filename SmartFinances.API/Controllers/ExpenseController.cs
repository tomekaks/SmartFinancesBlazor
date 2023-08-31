using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using SmartFinances.Application.Features.Expenses.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<ExpenseDto>>> GetAll(int accuntId)
        {
            var expenses = await _mediator.Send(new GetExpenseListRequest { AccountId = accuntId });
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDto>> Get(int id)
        {
            var expense = await _mediator.Send(new GetExpenseRequest { Id = id });
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseDto expenseDto)
        {
            await _mediator.Send(new CreateExpenseCommand { ExpenseDto = expenseDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditExpenseDto editExpenseDto)
        {
            await _mediator.Send(new UpdateExpenseCommand { ExpenseDto = editExpenseDto });
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteExpenseCommand { Id = id });
            return Ok();
        }
    }
}
