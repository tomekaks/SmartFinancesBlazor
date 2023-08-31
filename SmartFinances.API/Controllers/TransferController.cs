﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Commands;
using SmartFinances.Application.Features.Transfers.Requests.Queries;

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


        [HttpGet("{accountnumber}")]
        public async Task<ActionResult<List<TransferDto>>> GetAllTransfers(string accountNumber)
        {
            var transfers = await _mediator.Send(new GetTransferListRequest { AccountNumber = accountNumber });
            return Ok(transfers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransferDto>> GetTransfer(int id)
        {
            var transfers = await _mediator.Send(new GetTransferRequest { TransferId = id});
            return Ok(transfers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTransferDto createTransferDto)
        {
            await _mediator.Send(new CreateTransferCommand { TransferDto = createTransferDto });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreateTransferDto createTransferDto)
        {
            await _mediator.Send(new CreateTransferCommand { TransferDto = createTransferDto });
            return Ok();
        }
    }
}
