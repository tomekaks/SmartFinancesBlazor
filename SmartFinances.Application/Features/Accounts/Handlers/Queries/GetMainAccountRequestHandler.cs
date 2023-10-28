using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.Accounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Accounts.Handlers.Queries
{
    public class GetMainAccountRequestHandler : IRequestHandler<GetMainAccountRequest, AccountDto>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetMainAccountRequestHandler(IAccountFactory accountFactory, IUnitOfWork unitOfWork)
        {
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountDto> Handle(GetMainAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Accounts.GetAsync(q => q.UserId == request.UserId && q.Type == 1);

            if (account == null)
            {
                throw new BadRequestException("Could not find the account");
            }

            var accountDto = _accountFactory.CreateAccountDto(account);

            return accountDto;
        }
    }
}
