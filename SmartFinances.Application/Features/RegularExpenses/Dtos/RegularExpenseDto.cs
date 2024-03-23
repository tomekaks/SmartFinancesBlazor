using SmartFinances.Application.Features.ExpenseTypes.Dtos;

namespace SmartFinances.Application.Features.RegularExpenses.Dtos
{
    public class RegularExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseTypeDto ExpenseTypeDto { get; set; }
        public int TransactionalAccountId { get; set; }
    }
}
