namespace SmartFinances.Application.Features.RegularExpenses.Dtos
{
    public class EditRegularExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseTypeId { get; set; }
    }
}
