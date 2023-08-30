using SmartFinancesBlazorUI.Models.Enum;

namespace SmartFinancesBlazorUI.Models
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
        public int AccountId { get; set; }
        public bool IsRegular { get; set; }
    }
}
