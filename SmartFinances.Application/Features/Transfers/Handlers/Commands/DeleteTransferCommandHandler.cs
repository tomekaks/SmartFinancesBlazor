using MediatR;
using SmartFinances.Application.Features.Transfers.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Handlers.Commands
{
    public class DeleteTransferCommandHandler : IRequestHandler<DeleteTransferCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTransferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await _unitOfWork.Transfers.GetByIdAsync(request.TransferId);
            _unitOfWork.Transfers.Delete(transfer);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
