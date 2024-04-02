using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Queries
{
    public class GetUsersAccountRequestsRequestHandler : IRequestHandler<GetUsersAccountRequestsRequest, List<AccountRequestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public GetUsersAccountRequestsRequestHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task<List<AccountRequestDto>> Handle(GetUsersAccountRequestsRequest request, CancellationToken cancellationToken)
        {
            var accountRequests = await _unitOfWork.AccountRequests.GetAllAsync(q => q.UserId == request.UserId);

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestDto>();
            }

            var accountRequestsDto = _accountRequestFactory.GetAccountRequestDtoList(accountRequests.ToList());

            return accountRequestsDto;
        }
    }
}
