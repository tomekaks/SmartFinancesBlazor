using MediatR;
using SmartFinances.Application.Dto.RegularExpenseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Requests.Queries
{
    public class GetRegularExpenseRequest : IRequest<RegularExpenseDto>
    {
        public int Id { get; set; }
    }
}
