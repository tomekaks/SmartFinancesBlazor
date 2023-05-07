using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.CQRS.Account.Validators;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Handlers.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IAccountFactory accountFactory)
        {
            _unitOfWork = unitOfWork;
            _accountFactory = accountFactory;
        }

        //public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        //{
        //    CreateAccountCommandValidator validator = new();
        //    var validationResult = validator.Validate(request);

        //    if (!validationResult.IsValid)
        //    {
        //        throw new ValidationException(validationResult);
        //    }

        //    var account = _accountFactory.CreateAccount(request.UserId, request.AccountName);
        //    await _unitOfWork.Accounts.AddAsync(account);
        //    await _unitOfWork.SaveAsync();

        //    return Unit.Value;
        //}

        public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            CreateAccountCommandValidator validator = new();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var account = _accountFactory.CreateAccount(request.UserId, request.AccountName);
            await _unitOfWork.Accounts.AddAsync(account);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
