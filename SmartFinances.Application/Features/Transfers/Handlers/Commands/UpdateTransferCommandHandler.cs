using MediatR;
using SmartFinances.Application.Features.Transfers.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Handlers.Commands
{
    public class UpdateTransferCommandHandler : IRequestHandler<UpdateTransferCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public UpdateTransferCommandHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }
        public async Task Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await _unitOfWork.Transfers.GetByIdAsync(request.TransferDto.Id);
            transfer = _transferFactory.MapToModel(request.TransferDto, transfer);
            _unitOfWork.Transfers.Update(transfer);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
