using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.MonthlySummaries.Handlers.Queries
{
    public class GetMonthlySummariesByYearQueryHandler : IRequestHandler<GetMonthlySummariesByYearQuery, List<MonthlySummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMonthlySummaryFactory _monthlySummaryFactory;

        public GetMonthlySummariesByYearQueryHandler(IMonthlySummaryFactory monthlySummaryFactory, IUnitOfWork unitOfWork)
        {
            _monthlySummaryFactory = monthlySummaryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MonthlySummaryDto>> Handle(GetMonthlySummariesByYearQuery request, CancellationToken cancellationToken)
        {
            var monthlySummaries = await _unitOfWork.MonthlySummaries.GetAllAsync(q => q.YearlySummaryId == request.YearlySummaryId,
                                                                                       includeProperties: "Expenses");

            if (monthlySummaries == null || monthlySummaries.Count() > 12 )
            {
                throw new NotFoundException("MonthlySummaries", request.YearlySummaryId);
            }

            var monthlySummariesDto = _monthlySummaryFactory.CreateMonthlySummaryDtoList(monthlySummaries.ToList());

            return monthlySummariesDto;
        }
    }
}
