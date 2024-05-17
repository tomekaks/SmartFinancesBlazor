using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.MonthlySummaries.Dtos;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.MonthlySummaries.Handlers.Queries
{
    public class GetMonthlySummaryQueryHandler : IRequestHandler<GetMonthlySummaryQuery, MonthlySummaryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMonthlySummaryFactory _monthlySummaryFactory;

        public GetMonthlySummaryQueryHandler(IUnitOfWork unitOfWork, IMonthlySummaryFactory monthlySummaryFactory)
        {
            _unitOfWork = unitOfWork;
            _monthlySummaryFactory = monthlySummaryFactory;
        }

        public async Task<MonthlySummaryDto> Handle(GetMonthlySummaryQuery request, CancellationToken cancellationToken)
        {
            var monthlySummary = await _unitOfWork.MonthlySummaries.GetAsync(q => q.Id == request.MonthlySummaryId,
                                                                             includeProperties: "Expenses");

            if (monthlySummary == null)
            {
                throw new NotFoundException("MonthlySummary", request.MonthlySummaryId);
            }

            var monthlySummaryDto = _monthlySummaryFactory.CreateMonthlySummaryDto(monthlySummary);

            return monthlySummaryDto;
        }
    }
}
