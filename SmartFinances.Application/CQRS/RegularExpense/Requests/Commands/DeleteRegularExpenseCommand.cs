using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Requests.Commands
{
    public class DeleteRegularExpenseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
