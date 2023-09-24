using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.ExpenseTypes.Requests.Commands
{
    public class DeleteExpenseTypeCommand : IRequest
    {
        public int ExpenseTypeId { get; set; }
    }
}
