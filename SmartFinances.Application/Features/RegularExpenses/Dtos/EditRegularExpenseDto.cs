using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Dtos
{
    public class EditRegularExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
