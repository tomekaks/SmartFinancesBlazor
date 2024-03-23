namespace SmartFinances.Application.Features.YearlySummaries.Dtos
{
    public class CreateYearlySummaryDto
    {
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public int TransactionalAccountId { get; set; }
    }
}
