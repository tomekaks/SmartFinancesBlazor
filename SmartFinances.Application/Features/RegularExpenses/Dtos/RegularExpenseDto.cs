namespace SmartFinances.Application.Features.RegularExpenses.Dtos
{
    public class RegularExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
    }
}
