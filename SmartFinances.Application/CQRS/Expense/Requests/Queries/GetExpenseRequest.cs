using MediatR;
using SmartFinances.Application.Dto.ExpenseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Expense.Requests.Queries
{
    public class GetExpenseRequest : IRequest<ExpenseDto>
    {
        public int Id { get; set; }
    }
}
