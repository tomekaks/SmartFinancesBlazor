using MediatR;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Requests.Queries
{
    public class GetRegularExpenseListQuery : IRequest<List<RegularExpenseDto>>
    {
        public int AccountId { get; set; }
    }
}
