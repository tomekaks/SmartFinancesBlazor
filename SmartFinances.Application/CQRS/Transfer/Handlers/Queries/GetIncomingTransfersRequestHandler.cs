using MediatR;
using SmartFinances.Application.CQRS.Transfer.Requests.Queries;
using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Transfer.Handlers.Queries
{
    public class GetIncomingTransfersRequestHandler : IRequestHandler<GetIncomingTransfersRequest, List<IncomingTransferDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public GetIncomingTransfersRequestHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task<List<IncomingTransferDto>> Handle(GetIncomingTransfersRequest request, CancellationToken cancellationToken)
        {
            var incomingTransfers = await _unitOfWork.Transfers.GetAllAsync(q => q.ReceiverAccountNumber == request.AccountNumber, 
                                                                            includeProperties:"Account");

            return _transferFactory.CreateIncomingTransferDtoList(incomingTransfers.ToList());
        }
    }
}
