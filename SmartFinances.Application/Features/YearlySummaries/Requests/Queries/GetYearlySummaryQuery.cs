using MediatR;
using SmartFinances.Application.Features.YearlySummaries.Dtos;

namespace SmartFinances.Application.Features.YearlySummaries.Requests.Queries
{
    public class GetYearlySummaryQuery : IRequest<YearlySummaryDto>
    {
        public int TransactionalAccountId { get; set; }
        public int Year { get; set; }
    }
}
