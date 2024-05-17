using AutoMapper;
using MediatR;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.Transfers.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Handlers.Queries
{
    public class GetTransferQueryHandler : IRequestHandler<GetTransferQuery, TransferDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public GetTransferQueryHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task<TransferDto> Handle(GetTransferQuery request, CancellationToken cancellationToken)
        {
            var transfer = await _unitOfWork.Transfers.GetByIdAsync(request.TransferId);
            return _transferFactory.CreateTransferDto(transfer);
        }
    }
}
