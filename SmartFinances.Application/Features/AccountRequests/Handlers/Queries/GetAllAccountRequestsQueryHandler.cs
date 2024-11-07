using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Queries
{
    public class GetAllAccountRequestsQueryHandler : IRequestHandler<GetAllAccountRequestsQuery, List<AccountRequestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public GetAllAccountRequestsQueryHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task<List<AccountRequestDto>> Handle(GetAllAccountRequestsQuery request, CancellationToken cancellationToken)
        {
            var accountRequests = await _unitOfWork.AccountRequests.GetAllUnfilteredAsync();

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestDto>();
            }

            var accountRequestsDto = _accountRequestFactory.GetAccountRequestDtoList(accountRequests.ToList());

            return accountRequestsDto;
        }
    }
}
