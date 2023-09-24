using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Expenses.Validators;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Commands;
using SmartFinances.Application.Features.ExpenseTypes.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.ExpenseTypes.Handlers.Commands
{
    public class CreateExpenseTypeCommandHandler : IRequestHandler<CreateExpenseTypeCommand>
    {
        private readonly IExpenseTypeFactory _expenseTypeFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExpenseTypeCommandHandler(IExpenseTypeFactory expenseTypeFactory, IUnitOfWork unitOfWork)
        {
            _expenseTypeFactory = expenseTypeFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExpenseTypeCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var expenseType = _expenseTypeFactory.CreateExpenseType(request.ExpenseTypeDto);
            await _unitOfWork.ExpenseTypes.AddAsync(expenseType);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
