﻿using MediatR;
using Microsoft.IdentityModel.Tokens;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Features.AccountRequests.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.AccountRequests.Handlers.Queries
{
    public class GetUsersAccountRequestsQueryHandler : IRequestHandler<GetUsersAccountRequestsQuery, List<AccountRequestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRequestFactory _accountRequestFactory;

        public GetUsersAccountRequestsQueryHandler(IUnitOfWork unitOfWork, IAccountRequestFactory accountRequestFactory)
        {
            _unitOfWork = unitOfWork;
            _accountRequestFactory = accountRequestFactory;
        }

        public async Task<List<AccountRequestDto>> Handle(GetUsersAccountRequestsQuery request, CancellationToken cancellationToken)
        {
            List<AccountRequest> accountRequests = new();

            if (request.Status.IsNullOrEmpty())
            {
                accountRequests = (await _unitOfWork.AccountRequests.GetAllAsync(q => 
                q.UserId == request.UserId, includeProperties: Constants.ACCOUNTTYPE)).ToList();
            }
            else
            {
                accountRequests = (await _unitOfWork.AccountRequests.GetAllAsync(q =>
                q.UserId == request.UserId && q.Status == request.Status, includeProperties: Constants.ACCOUNTTYPE)).ToList();
            }

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestDto>();
            }

            var accountRequestsDto = _accountRequestFactory.GetAccountRequestDtoList(accountRequests);

            return accountRequestsDto;
        }
    }
}
