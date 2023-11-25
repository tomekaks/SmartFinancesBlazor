using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Commands;
using SmartFinances.Application.Features.MonthlySummaries.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.MonthlySummaries.Handlers.Commands
{
    public class UpdateMonthlySummaryCommandHandler : IRequestHandler<UpdateMonthlySummaryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMonthlySummaryFactory _monthlySummaryFactory;

        public UpdateMonthlySummaryCommandHandler(IUnitOfWork unitOfWork, IMonthlySummaryFactory monthlySummaryFactory)
        {
            _unitOfWork = unitOfWork;
            _monthlySummaryFactory = monthlySummaryFactory;
        }

        public async Task Handle(UpdateMonthlySummaryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMonthlySummaryCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var monthlySummary = await _unitOfWork.MonthlySummaries.GetByIdAsync(request.MonthlySummaryDto.Id);

            if (monthlySummary == null)
            {
                throw new NotFoundException("MonthlySummary", request.MonthlySummaryDto.Id);
            }

            monthlySummary = _monthlySummaryFactory.MapToModel(request.MonthlySummaryDto, monthlySummary);
            _unitOfWork.MonthlySummaries.Update(monthlySummary);
            await _unitOfWork.SaveAsync();
        }
    }
}
