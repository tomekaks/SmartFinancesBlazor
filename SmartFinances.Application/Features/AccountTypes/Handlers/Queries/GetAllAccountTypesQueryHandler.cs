﻿using MediatR;
using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Application.Features.AccountTypes.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.AccountTypes.Handlers.Queries
{
    public class GetAllAccountTypesQueryHandler : IRequestHandler<GetAllAccountTypesQuery, List<AccountTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountTypeFactory _accountTypeFactory;

        public GetAllAccountTypesQueryHandler(IUnitOfWork unitOfWork, IAccountTypeFactory accountTypeFactory)
        {
            _unitOfWork = unitOfWork;
            _accountTypeFactory = accountTypeFactory;
        }

        public async Task<List<AccountTypeDto>> Handle(GetAllAccountTypesQuery request, CancellationToken cancellationToken)
        {
            var accountTypes = await _unitOfWork.AccountTypes.GetAllAsync();

            if(accountTypes == null || !accountTypes.Any())
            {
                return new List<AccountTypeDto>();
            }

            var accountTypesDto = _accountTypeFactory.CreateAccountTypeDtoList(accountTypes.ToList());
            return accountTypesDto;
        }
    }
}
