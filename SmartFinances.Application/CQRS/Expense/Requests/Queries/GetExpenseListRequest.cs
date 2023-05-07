using MediatR;
using SmartFinances.Application.Dto.ExpenseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Expense.Requests.Queries
{
    public class GetExpenseListRequest : IRequest<List<ExpenseDto>>
    {
        public int AccountId { get; set; }
    }
}
