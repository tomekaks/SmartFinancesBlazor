using MediatR;
using Microsoft.IdentityModel.Tokens;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;

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
            List<AccountRequest> accountRequests;

            if (request.Status.IsNullOrEmpty())
            {
                accountRequests = (await _unitOfWork.AccountRequests.GetAllAsync(q => q.UserId == request.UserId)).ToList();
            }
            else
            {
                accountRequests = (await _unitOfWork.AccountRequests.GetUsersAccountRequestsByStatus(request.UserId, request.Status)).ToList();
            }


            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestDto>();
            }

            var accountRequestsDto = _accountRequestFactory.GetAccountRequestDtoList(accountRequests.ToList());

            return accountRequestsDto;
        }
    }
}
