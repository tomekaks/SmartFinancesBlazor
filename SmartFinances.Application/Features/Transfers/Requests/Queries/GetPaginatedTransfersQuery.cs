using MediatR;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Features.Transfers.Dtos;

namespace SmartFinances.Application.Features.Transfers.Requests.Queries
{
    public class GetPaginatedTransfersQuery : IRequest<PaginatedList<TransferDto>>
    {
        public string AccountNumber { get; set; }
        public int PageNumber { get; set; }
        public int PageSize  { get; set; }
    }
}
