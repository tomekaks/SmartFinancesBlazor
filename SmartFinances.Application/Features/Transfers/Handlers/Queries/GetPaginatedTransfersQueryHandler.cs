using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Transfers.Handlers.Queries
{
    public class GetPaginatedTransfersQueryHandler : IRequestHandler<GetPaginatedTransfersQuery, List<TransferDto>>
    {
        private readonly ITransferFactory _tranferFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetPaginatedTransfersQueryHandler(ITransferFactory tranferFactory, IUnitOfWork unitOfWork)
        {
            _tranferFactory = tranferFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TransferDto>> Handle(GetPaginatedTransfersQuery request, CancellationToken cancellationToken)
        {
            var transfers = await _unitOfWork.Transfers.GetPaginatedTransfersAsync(request.AccountNumber, request.PageNumber, request.PageSize);

            if (transfers == null || transfers.Count < 1)
            {
                return new List<TransferDto>();
            }

            var transfersDto = _tranferFactory.CreateTransferDtoList(transfers);
            return transfersDto;
        }
    }
}
