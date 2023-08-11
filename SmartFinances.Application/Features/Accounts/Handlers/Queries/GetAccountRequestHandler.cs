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
    public class GetAccountRequestHandler : IRequestHandler<GetAccountRequest, AccountDto>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetAccountRequestHandler(IUnitOfWork unitOfWork, IAccountFactory accountFactory)
        {
            _unitOfWork = unitOfWork;
            _accountFactory = accountFactory;
        }

        public async Task<AccountDto> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.GetAsync(q => q.UserId == request.UserId);
            return _accountFactory.CreateAccountDto(account);
        }
    }
}
