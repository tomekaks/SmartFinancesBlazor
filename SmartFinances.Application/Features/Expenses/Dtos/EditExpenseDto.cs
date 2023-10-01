using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class EditExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto ExpenseTypeDto { get; set; }
    }
}
