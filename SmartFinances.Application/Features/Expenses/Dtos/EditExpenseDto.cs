using SmartFinances.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class EditExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
    }
}
