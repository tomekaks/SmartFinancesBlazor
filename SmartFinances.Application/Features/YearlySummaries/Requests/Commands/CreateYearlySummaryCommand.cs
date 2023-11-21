using MediatR;
using SmartFinances.Application.Features.YearlySummaries.Dtos;

namespace SmartFinances.Application.Features.YearlySummaries.Requests.Commands
{
    public class CreateYearlySummaryCommand : IRequest
    {
        public CreateYearlySummaryDto YearlySummaryDto{ get; set; }
    }
}
