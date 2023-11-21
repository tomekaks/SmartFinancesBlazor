using AutoMapper;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.MonthlySummaries.Factories
{
    public class MonthlySummaryFactory : IMonthlySummaryFactory
    {
        private readonly IMapper _mapper;

        public MonthlySummaryFactory(IMapper mapper)
        {
            _mapper = mapper;
        }


        public MonthlySummary CreateMonthlySummary(MonthlySummaryDto monthlySummaryDto)
        {
            return _mapper.Map<MonthlySummary>(monthlySummaryDto);
        }

        public MonthlySummary CreateMonthlySummary(CreateMonthlySummaryDto monthlySummaryDto)
        {
            return _mapper.Map<MonthlySummary>(monthlySummaryDto);
        }

        public MonthlySummaryDto CreateMonthlySummaryDto(MonthlySummary monthlySummary)
        {
            return _mapper.Map<MonthlySummaryDto>(monthlySummary);
        }

        public List<MonthlySummaryDto> CreateMonthlySummaryDtoList(List<MonthlySummary> monthlySummaries)
        {
            return _mapper.Map<List<MonthlySummaryDto>>(monthlySummaries);
        }

        public MonthlySummary MapToModel(UpdateMonthlySummaryDto updateMonthlySummaryDto, MonthlySummary monthlySummary)
        {
            return _mapper.Map(updateMonthlySummaryDto, monthlySummary);
        }
    }
}
