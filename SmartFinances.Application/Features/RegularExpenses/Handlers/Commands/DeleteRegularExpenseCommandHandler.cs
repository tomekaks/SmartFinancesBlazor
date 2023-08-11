using MediatR;
using SmartFinances.Application.Features.RegularExpenses.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Handlers.Commands
{
    public class DeleteRegularExpenseCommandHandler : IRequestHandler<DeleteRegularExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRegularExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRegularExpenseCommand request, CancellationToken cancellationToken)
        {
            var regularExpense = await _unitOfWork.RegularExpenses.GetByIdAsync(request.Id);

            if (regularExpense != null)
            {
                _unitOfWork.RegularExpenses.Delete(regularExpense);
                await _unitOfWork.SaveAsync();
            }

            return;
        }
    }
}
