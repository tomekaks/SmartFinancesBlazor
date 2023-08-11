using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Core.Enums;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
        public bool IsRegular { get; set; }
    }
}
