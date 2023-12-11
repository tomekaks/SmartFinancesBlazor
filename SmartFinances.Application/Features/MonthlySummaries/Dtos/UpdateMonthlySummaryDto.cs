namespace SmartFinances.Application.Features.MonthlySummaries.Dtos
{
    public class UpdateMonthlySummaryDto
    {
        public int Id { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
    }
}
