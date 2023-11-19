using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;

namespace SmartFinances.Application.Features.YearlySummaries.Dtos
{
    public class YearlySummaryDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public List<MonthlySummaryDto> MonthlySummaries { get; set; }
        public int AccountId { get; set; }
        public AccountDto AccountDto { get; set; }
    }
}
