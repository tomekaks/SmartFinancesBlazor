using MediatR;
using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.Expenses.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Handlers.Queries
{
    public class GetExpenseListRequestHandler : IRequestHandler<GetExpenseListRequest, List<ExpenseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseFactory _expenseFactory;

        public GetExpenseListRequestHandler(IUnitOfWork unitOfWork, IExpenseFactory expenseFactory)
        {
            _unitOfWork = unitOfWork;
            _expenseFactory = expenseFactory;
        }

        public async Task<List<ExpenseDto>> Handle(GetExpenseListRequest request, CancellationToken cancellationToken)
        {
            var expenses = await _unitOfWork.Expenses.GetAllAsync(q => q.AccountId == request.AccountId);

            return _expenseFactory.CreateExpenseDtoList(expenses.ToList());
        }
    }
}
