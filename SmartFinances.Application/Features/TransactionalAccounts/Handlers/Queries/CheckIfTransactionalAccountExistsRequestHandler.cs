﻿using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Queries
{
    public class CheckIfTransactionalAccountExistsRequestHandler :
        IRequestHandler<CheckIfTransactionalAccountExistsRequest, TransactionalAccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ITransactionalAccountFactory _transactionalAccountFactory;

        public CheckIfTransactionalAccountExistsRequestHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task<TransactionalAccountDto> Handle(CheckIfTransactionalAccountExistsRequest request, CancellationToken cancellationToken)
        {
            var transactionalAccount = await _unitOfWork.TransactionalAccounts.GetAsync(q => q.Number == request.AccountNumber);
            
            if (transactionalAccount == null)
            {
                return null;
            }

            var accountDto = _transactionalAccountFactory.CreateTransactionalAccountDto(transactionalAccount);
            return accountDto;
        }
    }
}
