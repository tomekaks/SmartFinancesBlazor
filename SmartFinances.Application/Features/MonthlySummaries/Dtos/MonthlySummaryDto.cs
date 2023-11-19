using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Application.Features.YearlySummaries.Dtos;

namespace SmartFinances.Application.Features.MonthlySummaries.Dtos
{
    public class MonthlySummaryDto
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public List<ExpenseDto> Expenses { get; set; }
        public int YearlySummaryId { get; set; }
        public YearlySummaryDto YearlySummary { get; set; }
    }
}
