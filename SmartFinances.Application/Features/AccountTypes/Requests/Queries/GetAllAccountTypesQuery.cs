﻿using MediatR;
using SmartFinances.Application.Features.AccountTypes.Dtos;

namespace SmartFinances.Application.Features.AccountTypes.Requests.Queries
{
    public class GetAllAccountTypesQuery : IRequest<List<AccountTypeDto>>
    {
    }
}
