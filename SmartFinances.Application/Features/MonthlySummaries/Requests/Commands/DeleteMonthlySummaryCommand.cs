using MediatR;

namespace SmartFinances.Application.Features.MonthlySummaries.Requests.Commands
{
    public class DeleteMonthlySummaryCommand : IRequest
    {
        public int MonthySummaryId { get; set; }
    }
}
