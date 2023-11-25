using MediatR;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;

namespace SmartFinances.Application.Features.MonthlySummaries.Requests.Commands
{
    public class CreateMonthlySummaryCommand : IRequest
    {
        public CreateMonthlySummaryDto MonthlySummaryDto { get; set; }
    }
}
