using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.MonthlySummaries.Requests.Commands;
using SmartFinances.Application.Features.MonthlySummaries.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.MonthlySummaries.Handlers.Commands
{
    public class CreateMonthlySummaryCommandHandler : IRequestHandler<CreateMonthlySummaryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMonthlySummaryFactory _monthlySummaryFactory;

        public CreateMonthlySummaryCommandHandler(IUnitOfWork unitOfWork, IMonthlySummaryFactory monthlySummaryFactory)
        {
            _unitOfWork = unitOfWork;
            _monthlySummaryFactory = monthlySummaryFactory;
        }

        public async Task Handle(CreateMonthlySummaryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMonthlySummaryCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var monthlySummary = _monthlySummaryFactory.CreateMonthlySummary(request.MonthlySummaryDto);
            await _unitOfWork.MonthlySummaries.AddAsync(monthlySummary);
            await _unitOfWork.SaveAsync();
        }
    }
}
