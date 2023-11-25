using MediatR;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;

namespace SmartFinances.Application.Features.MonthlySummaries.Requests.Queries
{
    public class GetMonthlySummaryRequest : IRequest<MonthlySummaryDto>
    {
        public int MonthlySummaryId { get; set; }
    }
}
