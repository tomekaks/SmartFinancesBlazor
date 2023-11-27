using SmartFinances.Application.Features.ExpenseTypes.Dtos;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseTypeDto ExpenseTypeDto { get; set; }
        public int MonthlySummaryId { get; set; }
        public bool IsRegular { get; set; }
    }
}
