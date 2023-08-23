using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Transfers.Handlers.Queries
{
    public class GetTransferListRequestHandler : IRequestHandler<GetTransferListRequest, List<TransferDto>>
    {
        private readonly ITransferFactory _tranferFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetTransferListRequestHandler(ITransferFactory tranferFactory, IUnitOfWork unitOfWork)
        {
            _tranferFactory = tranferFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TransferDto>> Handle(GetTransferListRequest request, CancellationToken cancellationToken)
        {
            var transfers = await _unitOfWork.Transfers.GetAllAsync(q => q.SenderAccountNumber == request.AccountNumber || q.SenderAccountNumber == request.AccountNumber);
            
            if (!transfers.Any()) 
            {
                return new List<TransferDto>();
            }

            var transferList = _tranferFactory.CreateTransferDtoList(transfers.ToList());

            return transferList;

        }
    }
}
