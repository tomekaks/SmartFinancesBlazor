using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.ExpenseTypes.Requests.Commands;
using SmartFinances.Application.Features.ExpenseTypes.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.ExpenseTypes.Handlers.Commands
{
    public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommand>
    {
        private readonly IExpenseTypeFactory _expenseTypeFactory;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExpenseTypeCommandHandler(IExpenseTypeFactory expenseTypeFactory, IUnitOfWork unitOfWork)
        {
            _expenseTypeFactory = expenseTypeFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExpenseTypeCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var expenseType = await _unitOfWork.ExpenseTypes.GetByIdAsync(request.EditExpenseTypeDto.Id);

            if (expenseType == null)
            {
                throw new NotFoundException(request.EditExpenseTypeDto.Name, request.EditExpenseTypeDto);
            }

            expenseType = _expenseTypeFactory.MapToModel(request.EditExpenseTypeDto, expenseType);
            _unitOfWork.ExpenseTypes.Update(expenseType);
            await _unitOfWork.SaveAsync();
        }
    }
}
