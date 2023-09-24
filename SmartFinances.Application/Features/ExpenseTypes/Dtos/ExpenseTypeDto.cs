using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.ExpenseTypes.Dtos
{
    public class ExpenseTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
