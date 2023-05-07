using AutoMapper;
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
    public class GetOutgoingTransfersRequestHandler : IRequestHandler<GetOutgoingTransfersRequest, List<OutgoingTransferDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public GetOutgoingTransfersRequestHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task<List<OutgoingTransferDto>> Handle(GetOutgoingTransfersRequest request, CancellationToken cancellationToken)
        {
            var transferList = await _unitOfWork.Transfers.GetAllAsync(q => q.AccountId == request.AccountId);
            return _transferFactory.CreateTransferDtoList(transferList.ToList());
        }
    }
}
