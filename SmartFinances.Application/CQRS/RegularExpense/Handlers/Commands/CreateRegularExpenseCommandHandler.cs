using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.RegularExpense.Handlers.Validators;
using SmartFinances.Application.CQRS.RegularExpense.Requests.Commands;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Handlers.Commands
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
