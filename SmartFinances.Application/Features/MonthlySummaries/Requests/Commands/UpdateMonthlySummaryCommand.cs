using MediatR;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;

namespace SmartFinances.Application.Features.MonthlySummaries.Requests.Commands
{
    public class UpdateMonthlySummaryCommand : IRequest
    {
        public UpdateMonthlySummaryDto MonthlySummaryDto { get; set; }
    }
}
