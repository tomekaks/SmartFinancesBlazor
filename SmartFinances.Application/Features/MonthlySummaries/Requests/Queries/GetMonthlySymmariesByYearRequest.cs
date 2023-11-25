using MediatR;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;

namespace SmartFinances.Application.Features.MonthlySummaries.Requests.Queries
{
    public class GetMonthlySymmariesByYearRequest : IRequest<List<MonthlySummaryDto>>
    {
        public int YearlySummaryId { get; set; }
    }
}
