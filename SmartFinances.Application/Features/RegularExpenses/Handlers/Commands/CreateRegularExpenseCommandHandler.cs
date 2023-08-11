using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.RegularExpenses.Handlers.Validators;
using SmartFinances.Application.Features.RegularExpenses.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.RegularExpenses.Handlers.Commands
{
    public class CreateRegularExpenseCommandHandler : IRequestHandler<CreateRegularExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegularExpenseFactory _regularExpenseFactory;

        public CreateRegularExpenseCommandHandler(IUnitOfWork unitOfWork, IRegularExpenseFactory regularExpenseFactory)
        {
            _unitOfWork = unitOfWork;
            _regularExpenseFactory = regularExpenseFactory;
        }

        public async Task Handle(CreateRegularExpenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRegularExpenseCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var regularExpense = _regularExpenseFactory.CreateRegularExpense(request.RegularExpenseDto);
            await _unitOfWork.RegularExpenses.AddAsync(regularExpense);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
