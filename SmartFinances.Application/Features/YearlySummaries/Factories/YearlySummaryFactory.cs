using AutoMapper;
using SmartFinances.Application.Features.YearlySummaries.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.YearlySummaries.Factories
{
    public class YearlySummaryFactory : IYearlySummaryFactory
    {
        private readonly IMapper _mapper;

        public YearlySummaryFactory(IMapper mapper)
        {
            _mapper = mapper;
        }


        public YearlySummary CreateYearlySummary(YearlySummaryDto yearlySummaryDto)
        {
            return _mapper.Map<YearlySummary>(yearlySummaryDto);
        }

        public YearlySummary CreateYearlySummary(CreateYearlySummaryDto yearlySummaryDto)
        {
            return _mapper.Map<YearlySummary>(yearlySummaryDto);
        }

        public YearlySummaryDto CreateYearlySummaryDto(YearlySummary yearlySummary)
        {
            return _mapper.Map<YearlySummaryDto>(yearlySummary);
        }

        public YearlySummary MapToModel(UpdateYearlySummaryDto updateYearlySummaryDto, YearlySummary yearlySummary)
        {
            return _mapper.Map(updateYearlySummaryDto, yearlySummary);
        }
    }
}
