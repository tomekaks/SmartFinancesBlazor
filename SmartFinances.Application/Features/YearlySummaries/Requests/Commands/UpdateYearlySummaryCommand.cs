using MediatR;
using SmartFinances.Application.Features.YearlySummaries.Dtos;

namespace SmartFinances.Application.Features.YearlySummaries.Requests.Commands
{
    public class UpdateYearlySummaryCommand : IRequest
    {
        public UpdateYearlySummaryDto YearlySummaryDto{ get; set; }
    }
}
