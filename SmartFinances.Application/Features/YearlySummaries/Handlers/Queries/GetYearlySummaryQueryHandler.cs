using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.YearlySummaries.Dtos;
using SmartFinances.Application.Features.YearlySummaries.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.YearlySummaries.Handlers.Queries
{
    public class GetYearlySummaryQueryHandler : IRequestHandler<GetYearlySummaryQuery, YearlySummaryDto>
    {
        private readonly IYearlySummaryFactory _yearlySummaryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetYearlySummaryQueryHandler(IYearlySummaryFactory yearlySummaryFactory, IUnitOfWork unitOfWork)
        {
            _yearlySummaryFactory = yearlySummaryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<YearlySummaryDto> Handle(GetYearlySummaryQuery request, CancellationToken cancellationToken)
        {
            var yearlySummary = await _unitOfWork.YearlySummaries.GetYearlySummaryWithChildren(request.TransactionalAccountId, request.Year);

            if (yearlySummary == null)
            {
                return null;
            }

            var yearlySummaryDto = _yearlySummaryFactory.CreateYearlySummaryDto(yearlySummary);

            return yearlySummaryDto;
        }
    }
}
