using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Commands;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Queries;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenseTypeDto>>> GetAllAsync()
        {
            var expenses = await _mediator.Send(new GetExpenseTypesRequest());
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseTypeDto>> GetAsync(int id)
        {
            var expense = await _mediator.Send(new GetExpenseTypeRequest { ExpenseTypeId = id });
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ExpenseTypeDto expenseTypeDto)
        {
            await _mediator.Send(new CreateExpenseTypeCommand { ExpenseTypeDto = expenseTypeDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EditExpenseTypeDto editexpenseTypeDto)
        {
            await _mediator.Send(new UpdateExpenseTypeCommand { EditExpenseTypeDto = editexpenseTypeDto });
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new DeleteExpenseTypeCommand { ExpenseTypeId = id });
            return Ok();
        }
    }
}
