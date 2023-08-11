using MediatR;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.Accounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Accounts.Handlers.Queries
{
    public class GetAccountByNumberRequestHandler : IRequestHandler<GetAccountByNumberRequest, AccountDto>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetAccountByNumberRequestHandler(IAccountFactory accountFactory, IUnitOfWork unitOfWork)
        {
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountDto> Handle(GetAccountByNumberRequest request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.GetAsync(q => q.Number == request.AccountNumber);

            if (account == null)
            {
                return null;
            }

            return _accountFactory.CreateAccountDto(account);
        }
    }
}
