using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using SmartFinances.Application.Features.Expenses.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Expenses.Handlers.Commands
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseFactory _expenseFactory;

        public CreateExpenseCommandHandler(IUnitOfWork unitOfWork, IExpenseFactory expenseFactory)
        {
            _unitOfWork = unitOfWork;
            _expenseFactory = expenseFactory;
        }

        public async Task Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExpenseCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var expense = _expenseFactory.CreateExpense(request.ExpenseDto);
            await _unitOfWork.Expenses.AddAsync(expense);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
