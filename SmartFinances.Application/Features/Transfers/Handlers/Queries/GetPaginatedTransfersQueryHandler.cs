using MediatR;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Transfers.Handlers.Queries
{
    public class GetPaginatedTransfersQueryHandler : IRequestHandler<GetPaginatedTransfersQuery, PaginatedList<TransferDto>>
    {
        private readonly ITransferFactory _tranferFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetPaginatedTransfersQueryHandler(ITransferFactory tranferFactory, IUnitOfWork unitOfWork)
        {
            _tranferFactory = tranferFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedList<TransferDto>> Handle(GetPaginatedTransfersQuery request, CancellationToken cancellationToken)
        {
            int totalTransfers = await _unitOfWork.Transfers.GetTransfersCountByAccountNumberAsync(request.AccountNumber);
            int totalPages = (int)Math.Ceiling((double)totalTransfers / request.PageSize);

            var transfers = await _unitOfWork.Transfers.GetPaginatedTransfersAsync(request.AccountNumber, request.PageNumber, request.PageSize);

            if (transfers == null || transfers.Count < 1)
            {
                return new PaginatedList<TransferDto>();
            }

            var transfersDto = _tranferFactory.CreatePaginatedListOfTransfers(
                transfers, request.PageNumber, request.PageSize, totalPages, totalTransfers);

            return transfersDto;
        }
    }
}
