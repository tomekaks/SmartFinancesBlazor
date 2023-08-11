using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Expenses.Requests.Commands;
using SmartFinances.Application.Features.Expenses.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Expenses.Handlers.Commands
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseFactory _expenseFactory;

        public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IExpenseFactory expenseFactory)
        {
            _unitOfWork = unitOfWork;
            _expenseFactory = expenseFactory;
        }

        public async Task Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExpenseCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var expense = await _unitOfWork.Expenses.GetByIdAsync(request.ExpenseDto.Id);
            expense = _expenseFactory.MapToModel(request.ExpenseDto, expense);

            _unitOfWork.Expenses.Update(expense);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
