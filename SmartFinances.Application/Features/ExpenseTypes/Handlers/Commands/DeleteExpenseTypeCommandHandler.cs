using MediatR;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.ExpenseTypes.Handlers.Commands
{
    public class DeleteExpenseTypeCommandHandler : IRequestHandler<DeleteExpenseTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var expenseType = await _unitOfWork.ExpenseTypes.GetByIdAsync(request.ExpenseTypeId);

            if (expenseType != null)
            {
                _unitOfWork.ExpenseTypes.Delete(expenseType);
                await _unitOfWork.SaveAsync();
            }

            return;
        }
    }
}
