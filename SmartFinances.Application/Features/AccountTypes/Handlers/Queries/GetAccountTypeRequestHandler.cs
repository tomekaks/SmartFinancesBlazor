using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Application.Features.AccountTypes.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountTypes.Handlers.Queries
{
    public class GetAccountTypeRequestHandler : IRequestHandler<GetAccountTypeRequest, AccountTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountTypeFactory _accountTypeFactory;

        public GetAccountTypeRequestHandler(IUnitOfWork unitOfWork, IAccountTypeFactory accountTypeFactory)
        {
            _unitOfWork = unitOfWork;
            _accountTypeFactory = accountTypeFactory;
        }

        public async Task<AccountTypeDto> Handle(GetAccountTypeRequest request, CancellationToken cancellationToken)
        {
            var accountType = await _unitOfWork.AccountTypes.GetByIdAsync(request.AccountTypeId);

            if (accountType == null)
            {
                throw new NotFoundException("AccountType", request.AccountTypeId);
            }

            var accountTypeDto = _accountTypeFactory.CreateAccountTypeDto(accountType);
            return accountTypeDto;
        }
    }
}
