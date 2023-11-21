using MediatR;
using SmartFinances.Application.Features.YearlySummaries.Dtos;
using SmartFinances.Application.Features.YearlySummaries.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.YearlySummaries.Handlers.Queries
{
    public class GetYearlySummaryRequestHandler : IRequestHandler<GetYearlySummaryRequest, YearlySummaryDto>
    {
        private readonly IYearlySummaryFactory _yearlySummaryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetYearlySummaryRequestHandler(IYearlySummaryFactory yearlySummaryFactory, IUnitOfWork unitOfWork)
        {
            _yearlySummaryFactory = yearlySummaryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<YearlySummaryDto> Handle(GetYearlySummaryRequest request, CancellationToken cancellationToken)
        {
            var yearlySummary = await _unitOfWork.YearlySummaries.GetAsync(q => q.AccountId == request.AccountId &&
                                                                                 q.Year == request.Year);

            if (yearlySummary == null)
            {
                throw new Exception("Yearly summary does not exist");
            }

            var yearlySummaryDto = _yearlySummaryFactory.CreateYearlySummaryDto(yearlySummary);

            return yearlySummaryDto;
        }
    }
}
