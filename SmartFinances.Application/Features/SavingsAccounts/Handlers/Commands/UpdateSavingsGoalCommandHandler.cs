﻿using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Commands;
using SmartFinances.Application.Features.SavingsAccounts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Application.Exceptions;

namespace SmartFinances.Application.Features.SavingsAccounts.Handlers.Commands
{
    public class UpdateSavingsGoalCommandHandler : IRequestHandler<UpdateSavingsGoalCommand> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavingsAccountFactory _savingsAccountFactory;

        public UpdateSavingsGoalCommandHandler(IUnitOfWork unitOfWork, ISavingsAccountFactory savingsAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _savingsAccountFactory = savingsAccountFactory;
        }

        public async Task Handle(UpdateSavingsGoalCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSavingsGoalCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var savingsAccount = await _unitOfWork.SavingsAccounts.GetByIdAsync(request.UpdateAccountDto.Id);

            if (savingsAccount == null)
            {
                throw new NotFoundException("SavingsAccount", request.UpdateAccountDto.Id);
            }

            savingsAccount.Goal = request.UpdateAccountDto.Goal;

            _unitOfWork.SavingsAccounts.Update(savingsAccount);
            await _unitOfWork.SaveAsync();
        }
    }
}
