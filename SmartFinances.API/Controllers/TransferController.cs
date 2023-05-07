using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.CQRS.Transfer.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.TransferDtos;

namespace SmartFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getincomingtransfers")]
        public async Task<ActionResult<List<IncomingTransferDto>>> GetIncomingTransfers(AccountDto accountDto)
        {
            var incomingTransfers = await _mediator.Send(new GetIncomingTransfersRequest { AccountNumber = accountDto.Number });
            return Ok(incomingTransfers);
        }

        [HttpGet("getoutgoingtransfers")]
        public async Task<ActionResult<List<OutgoingTransferDto>>> GetOutgoigTransfers(AccountDto accountDto)
        {
            var outgoingTransfers = await _mediator.Send(new GetOutgoingTransfersRequest { AccountId = accountDto.Id });
            return Ok(outgoingTransfers);
        }
    }
}
