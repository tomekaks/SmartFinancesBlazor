using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using SmartFinances.Application.Features.Expenses.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenseDto>>> GetAllAsync(int accuntId)
        {
            var expenses = await _mediator.Send(new GetExpenseListRequest { AccountId = accuntId });
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDto>> GetAsync(int id)
        {
            var expense = await _mediator.Send(new GetExpenseRequest { Id = id });
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ExpenseDto expenseDto)
        {
            await _mediator.Send(new CreateExpenseCommand { ExpenseDto = expenseDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EditExpenseDto editExpenseDto)
        {
            await _mediator.Send(new UpdateExpenseCommand { ExpenseDto = editExpenseDto });
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteExpenseCommand { Id = id });
            return Ok();
        }
    }
}
