using MediatR;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.MonthlySummaries.Handlers.Queries
{
    public class GetMonthlySummariesByYearRequestHandler : IRequestHandler<GetMonthlySymmariesByYearRequest, List<MonthlySummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMonthlySummaryFactory _monthlySummaryFactory;

        public GetMonthlySummariesByYearRequestHandler(IMonthlySummaryFactory monthlySummaryFactory, IUnitOfWork unitOfWork)
        {
            _monthlySummaryFactory = monthlySummaryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MonthlySummaryDto>> Handle(GetMonthlySymmariesByYearRequest request, CancellationToken cancellationToken)
        {
            var monthlySummaries = await _unitOfWork.MonthlySummaries.GetAllAsync(q => q.YearlySummaryId == request.YearlySummaryId);

            if (monthlySummaries == null || !monthlySummaries.Any())
            {
                return new List<MonthlySummaryDto>();
            }

            var monthlySummariesDto = _monthlySummaryFactory.CreateMonthlySummaryDtoList(monthlySummaries.ToList());

            return monthlySummariesDto;
        }
    }
}
