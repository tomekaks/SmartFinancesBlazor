using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class EditExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
