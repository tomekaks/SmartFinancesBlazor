using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Transfers.Handlers.Queries
{
    public class GetTransferListQueryHandler : IRequestHandler<GetTransferListQuery, List<TransferDto>>
    {
        private readonly ITransferFactory _tranferFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetTransferListQueryHandler(ITransferFactory tranferFactory, IUnitOfWork unitOfWork)
        {
            _tranferFactory = tranferFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TransferDto>> Handle(GetTransferListQuery request, CancellationToken cancellationToken)
        {
            var transfers = await _unitOfWork.Transfers.GetAllAsync(q => q.SenderAccountNumber == request.AccountNumber || q.ReceiverAccountNumber == request.AccountNumber);
            
            if (!transfers.Any()) 
            {
                return new List<TransferDto>();
            }

            var transferList = _tranferFactory.CreateTransferDtoList(transfers.ToList());

            return transferList;

        }
    }
}
