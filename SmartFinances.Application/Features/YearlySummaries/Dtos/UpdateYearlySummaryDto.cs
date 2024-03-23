namespace SmartFinances.Application.Features.YearlySummaries.Dtos
{
    public class UpdateYearlySummaryDto
    {
        public int Id { get; set; }
        public decimal Budget { get; set; }
        public decimal AmountSpent { get; set; }
        public decimal AmountSaved { get; set; }
        public int AccountId { get; set; }
        public int TransactionalAccountId { get; set; }
    }
}
