using MediatR;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Handlers.Commands
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _unitOfWork.Expenses.GetAsync(q => q.Id == request.Id);

            if (expense != null)
            {
                _unitOfWork.Expenses.Delete(expense);
                await _unitOfWork.SaveAsync();
            }
            return;
        }
    }
}
