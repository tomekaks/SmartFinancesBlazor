﻿using MediatR;
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
    internal class GetExpenseRequestHandler : IRequestHandler<GetExpenseRequest, ExpenseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseFactory _expenseFactory;

        public GetExpenseRequestHandler(IUnitOfWork unitOfWork, IExpenseFactory expenseFactory)
        {
            _unitOfWork = unitOfWork;
            _expenseFactory = expenseFactory;
        }

        public async Task<ExpenseDto> Handle(GetExpenseRequest request, CancellationToken cancellationToken)
        {
            var expense = await _unitOfWork.Expenses.GetAsync(q => q.Id == request.Id);
            return _expenseFactory.CreateExpenseDto(expense);
        }
    }
}
