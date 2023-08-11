using MediatR;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Requests.Commands
{
    public class UpdateRegularExpenseCommand : IRequest
    {
        public RegularExpenseDto RegularExpenseDto { get; set; }
    }
}
