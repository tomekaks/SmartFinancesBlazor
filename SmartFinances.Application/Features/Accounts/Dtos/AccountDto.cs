using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Dtos;

namespace SmartFinances.Application.Features.Accounts.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public List<RegularExpenseDto> RegularExpenses { get; set; }
        public decimal Budget { get; set; }
    }
}
