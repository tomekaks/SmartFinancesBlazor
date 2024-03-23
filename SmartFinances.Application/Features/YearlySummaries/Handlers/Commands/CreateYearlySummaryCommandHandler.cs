using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.YearlySummaries.Requests.Commands;
using SmartFinances.Application.Features.YearlySummaries.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.YearlySummaries.Handlers.Commands
{
    public class CreateYearlySummaryCommandHandler : IRequestHandler<CreateYearlySummaryCommand>
    {
        private readonly IYearlySummaryFactory _yearlySummaryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateYearlySummaryCommandHandler(IYearlySummaryFactory yearlySummaryFactory, IUnitOfWork unitOfWork)
        {
            _yearlySummaryFactory = yearlySummaryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateYearlySummaryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateYearlySummaryCommandValidator();
            var validationResult  = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var yearlySummary = _yearlySummaryFactory.CreateYearlySummary(request.YearlySummaryDto);
            await _unitOfWork.YearlySummaries.AddAsync(yearlySummary);
            await _unitOfWork.SaveAsync();

            //tomek

            yearlySummary = await _unitOfWork.YearlySummaries.GetAsync(
                                    q => q.TransactionalAccountId == request.YearlySummaryDto.TransactionalAccountId
                                    && q.Year == request.YearlySummaryDto.Year);

            //yearlySummary = await _unitOfWork.YearlySummaries.GetAsync(q => q.AccountId == request.YearlySummaryDto.AccountId
            //                                                             && q.Year == request.YearlySummaryDto.Year);

            await CreateMonthlySummariesAsync(yearlySummary);
        }

        private async Task CreateMonthlySummariesAsync(YearlySummary yearlySummary)
        {
            for(var i = 1; i <= 12; i++)
            {
                var monthlySummary = new MonthlySummary()
                {
                    Month = i,
                    Year = yearlySummary.Year,
                    YearlySummaryId = yearlySummary.Id
                };

                await _unitOfWork.MonthlySummaries.AddAsync(monthlySummary);
            }
            await _unitOfWork.SaveAsync();
        }

        
    }
}
