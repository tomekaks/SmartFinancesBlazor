using SmartFinances.Application.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto.ExpenseDtos
{
    public class EditExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto Type { get; set; }
    }
}
