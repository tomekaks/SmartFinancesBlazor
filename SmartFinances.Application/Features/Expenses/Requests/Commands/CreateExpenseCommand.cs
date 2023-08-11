using MediatR;
using SmartFinances.Application.Features.Expenses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Requests.Commands
{
    public class CreateExpenseCommand : IRequest
    {
        public ExpenseDto ExpenseDto { get; set; }
    }
}
