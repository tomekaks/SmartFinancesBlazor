using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;

namespace SmartFinances.Application.Features.Transfers.Requests.Queries
{
    public class GetPaginatedTransfersQuery : IRequest<List<TransferDto>>
    {
        public string AccountNumber { get; set; }
        public int PageNumber { get; set; }
        public int PageSize  { get; set; }
    }
}
