using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Requests.Queries
{
    public class GetTransferListRequest : IRequest<List<TransferDto>>
    {
        public string AccountNumber { get; set; }
    }
}
