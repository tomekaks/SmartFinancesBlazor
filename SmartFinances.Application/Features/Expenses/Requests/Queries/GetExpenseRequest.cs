using MediatR;
using SmartFinances.Application.Features.Expenses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Requests.Queries
{
    public class GetExpenseRequest : IRequest<ExpenseDto>
    {
        public int Id { get; set; }
    }
}
