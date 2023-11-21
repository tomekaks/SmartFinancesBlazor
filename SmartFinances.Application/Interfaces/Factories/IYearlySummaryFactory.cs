using SmartFinances.Application.Features.YearlySummaries.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IYearlySummaryFactory
    {
        YearlySummary CreateYearlySummary(YearlySummaryDto yearlySummaryDto);
        YearlySummary CreateYearlySummary(CreateYearlySummaryDto yearlySummaryDto);
        YearlySummaryDto CreateYearlySummaryDto(YearlySummary yearlySummary);
        YearlySummary MapToModel(UpdateYearlySummaryDto updateYearlySummaryDto, YearlySummary yearlySummary);
    }
}
