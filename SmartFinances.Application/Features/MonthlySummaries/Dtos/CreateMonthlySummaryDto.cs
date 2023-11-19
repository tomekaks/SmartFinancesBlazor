namespace SmartFinances.Application.Features.MonthlySummaries.Dtos
{
    public class CreateMonthlySummaryDto
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public int YearlySummaryId { get; set; }
    }
}
