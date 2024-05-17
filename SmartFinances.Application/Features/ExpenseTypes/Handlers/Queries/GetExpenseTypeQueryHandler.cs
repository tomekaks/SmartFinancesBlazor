using MediatR;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.ExpenseTypes.Handlers.Queries
{
    public class GetExpenseTypeQueryHandler : IRequestHandler<GetExpenseTypeQuery, ExpenseTypeDto>
    {
        private readonly IExpenseTypeFactory _expenseTypeFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetExpenseTypeQueryHandler(IExpenseTypeFactory expenseTypeFactory, IUnitOfWork unitOfWork)
        {
            _expenseTypeFactory = expenseTypeFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExpenseTypeDto> Handle(GetExpenseTypeQuery request, CancellationToken cancellationToken)
        {
            var expenseType = await _unitOfWork.ExpenseTypes.GetByIdAsync(request.ExpenseTypeId);

            if (expenseType == null)
            {
                return new ExpenseTypeDto();
            }

            return _expenseTypeFactory.CreateExpenseTypeDto(expenseType);
        }
    }
}
