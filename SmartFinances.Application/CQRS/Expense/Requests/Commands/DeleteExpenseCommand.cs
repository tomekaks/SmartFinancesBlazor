using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Expense.Requests.Commands
{
    public class DeleteExpenseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
