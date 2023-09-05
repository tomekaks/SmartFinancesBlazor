namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class EditExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
