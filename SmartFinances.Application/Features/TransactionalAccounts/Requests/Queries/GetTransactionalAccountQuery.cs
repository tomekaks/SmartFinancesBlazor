﻿using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries
{
    public class GetTransactionalAccountQuery : IRequest<TransactionalAccountDto>
    {
        public int AccountId { get; set; }
    }
}
