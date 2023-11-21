using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;
using SmartFinances.Application.Features.YearlySummaries.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.YearlySummaries.Handlers.Commands
{
    public class UpdateYearlySummaryCommandHandler : IRequestHandler<UpdateYearlySummaryCommand>
    {
        private readonly IYearlySummaryFactory _yearlySummaryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateYearlySummaryCommandHandler(IYearlySummaryFactory yearlySummaryFactory, IUnitOfWork unitOfWork)
        {
            _yearlySummaryFactory = yearlySummaryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateYearlySummaryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateYearlySummaryCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var yearlySummary = await _unitOfWork.YearlySummaries.GetByIdAsync(request.YearlySummaryDto.Id);

            if (yearlySummary == null)
            {
                throw new NotFoundException("YearlySummary", request.YearlySummaryDto.Id);
            }

            yearlySummary = _yearlySummaryFactory.MapToModel(request.YearlySummaryDto, yearlySummary);
            _unitOfWork.YearlySummaries.Update(yearlySummary);
            await _unitOfWork.SaveAsync();
        }
    }
}
