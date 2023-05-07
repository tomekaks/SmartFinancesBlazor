using MediatR;
using SmartFinances.Application.Dto.RegularExpenseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Requests.Commands
{
    public class CreateRegularExpenseCommand : IRequest
    {
        public RegularExpenseDto RegularExpenseDto{ get; set; }
    }
}
