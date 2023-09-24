using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public int AccountId { get; set; }
        public bool IsRegular { get; set; }
    }
}
