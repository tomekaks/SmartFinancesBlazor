using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.MonthlySummaries.Handlers.Commands
{
    public class DeleteMonthlySummaryCommandHandler : IRequestHandler<DeleteMonthlySummaryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMonthlySummaryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMonthlySummaryCommand request, CancellationToken cancellationToken)
        {
            var monthlySummary = await _unitOfWork.MonthlySummaries.GetByIdAsync(request.MonthySummaryId);

            if (monthlySummary == null)
            {
                throw new NotFoundException("MonthlySummary", request.MonthySummaryId);
            }

            _unitOfWork.MonthlySummaries.Delete(monthlySummary);
            await _unitOfWork.SaveAsync();
        }
    }
}
