using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Queries
{
    public class GetAccountRequestRequestHandler : IRequestHandler<GetAccountRequestRequest, AccountRequestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public GetAccountRequestRequestHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task<AccountRequestDto> Handle(GetAccountRequestRequest request, CancellationToken cancellationToken)
        {
            var accountRequest = await _unitOfWork.AccountRequests.GetByIdAsync(request.AccountRequestId);

            if (accountRequest == null)
            {
                throw new NotFoundException("Account request", request.AccountRequestId);
            }

            var accountRequestDto = _accountRequestFactory.CreateAccountRequestDto(accountRequest);

            return accountRequestDto;
        }
    }
}
