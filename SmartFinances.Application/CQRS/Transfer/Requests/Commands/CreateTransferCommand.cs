using MediatR;
using SmartFinances.Application.Dto.TransferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Transfer.Requests.Commands
{
    public class CreateTransferCommand : IRequest
    {
        public OutgoingTransferDto TransferDto { get; set; }
    }
}
