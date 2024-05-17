using MediatR;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Queries
{
    public class GetAccountRequestsByStatusQueryHandler : IRequestHandler<GetAccountRequestsByStatusQuery, List<AccountRequestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public GetAccountRequestsByStatusQueryHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task<List<AccountRequestDto>> Handle(GetAccountRequestsByStatusQuery request, CancellationToken cancellationToken)
        {
            //var accountRequests = await _unitOfWork.AccountRequests.GetAllAsync(q => 
            //    q.Status == request.Status, includeProperties: Constants.ACCOUNTTYPE);

            var accountRequests = await _unitOfWork.AccountRequests.GetAllByStatusAsync(request.Status);

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestDto>();
            }

            var accountRequestsDto = _accountRequestFactory.GetAccountRequestDtoList(accountRequests.ToList());

            return accountRequestsDto;
        }
    }
}
