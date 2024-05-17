using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Queries
{
    public class GetAccountRequestQueryHandler : IRequestHandler<GetAccountRequestQuery, AccountRequestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public GetAccountRequestQueryHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task<AccountRequestDto> Handle(GetAccountRequestQuery request, CancellationToken cancellationToken)
        {
            var accountRequest = await _unitOfWork.AccountRequests.GetAsync(q => 
                q.Id == request.AccountRequestId, includeProperties: Constants.ACCOUNTTYPE);

            if (accountRequest == null)
            {
                throw new NotFoundException("Account request", request.AccountRequestId);
            }

            var accountRequestDto = _accountRequestFactory.CreateAccountRequestDto(accountRequest);

            return accountRequestDto;
        }
    }
}
