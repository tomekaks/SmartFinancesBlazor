using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IMonthlySummaryFactory
    {
        MonthlySummary CreateMonthlySummary(MonthlySummaryDto monthlySummaryDto);
        MonthlySummary CreateMonthlySummary(CreateMonthlySummaryDto monthlySummaryDto);
        MonthlySummaryDto CreateMonthlySummaryDto(MonthlySummary monthlySummary);
        MonthlySummary MapToModel(UpdateMonthlySummaryDto updateMonthlySummaryDto, MonthlySummary monthlySummary);
        List<MonthlySummaryDto> CreateMonthlySummaryDtoList(List<MonthlySummary> monthlySummaries);
    }
}
