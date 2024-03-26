using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Commands;
using SmartFinances.Application.Features.Transfers.Requests.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransfersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("transfersGetAll/{accountNumber}")]
        public async Task<ActionResult<List<TransferDto>>> GetAllAsync(string accountNumber)
        {
            var transfers = await _mediator.Send(new GetTransferListRequest { AccountNumber = accountNumber });
            return Ok(transfers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransferDto>> GetAsync(int id)
        {
            var transfers = await _mediator.Send(new GetTransferRequest { TransferId = id});
            return Ok(transfers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]CreateTransferDto createTransferDto)
        {
            await _mediator.Send(new CreateTransferCommand { TransferDto = createTransferDto });
            return Ok();
        }

        [HttpPost("deposit")]
        [SwaggerOperation(OperationId = "TransfersDepositToSavingsAccount")]
        public async Task<IActionResult> DepositToSavingsAccountAsync([FromBody] SavingsAccountTransferDto savingsAccountTransferDto)
        {
            await _mediator.Send(new DepositToSavingsAccountCommand { TransferDto = savingsAccountTransferDto });
            return Ok();
        }

        [HttpPost("withdraw")]
        [SwaggerOperation(OperationId = "TransfersWithdrawFromSavingsAccount")]
        public async Task<IActionResult> WithdrawFromSavingsAccountAsync([FromBody] SavingsAccountTransferDto savingsAccountTransferDto)
        {
            await _mediator.Send(new WithdrawFromSavingsAccountCommand { TransferDto = savingsAccountTransferDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateTransferDto updateTransferDto)
        {
            await _mediator.Send(new UpdateTransferCommand { TransferDto = updateTransferDto });
            return Ok();
        }
    }
}
