﻿using MediatR;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.ExpenseTypes.Handlers.Queries
{
    public class GetExpenseTypesQueryHandler : IRequestHandler<GetExpenseTypesQuery, List<ExpenseTypeDto>>
    {
        private readonly IExpenseTypeFactory _expenseTypeFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetExpenseTypesQueryHandler(IExpenseTypeFactory expenseTypeFactory, IUnitOfWork unitOfWork)
        {
            _expenseTypeFactory = expenseTypeFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExpenseTypeDto>> Handle(GetExpenseTypesQuery request, CancellationToken cancellationToken)
        {
            var expenseTypes = await _unitOfWork.ExpenseTypes.GetAllAsync();

            if (expenseTypes == null || !expenseTypes.Any())
            {
                return new List<ExpenseTypeDto>();
            }

            return _expenseTypeFactory.CreateExpenseTypeDtoList(expenseTypes.ToList());
        }
    }
}
