using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;

namespace SmartFinances.Application.Features.Transfers.Requests.Queries
{
    public class GetTransferListQuery : IRequest<List<TransferDto>>
    {
        public string AccountNumber { get; set; }
    }
}
