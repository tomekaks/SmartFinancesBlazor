using MediatR;
using SmartFinances.Application.Features.Accounts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Accounts.Requests.Queries
{
    public class GetAccountByNumberRequest : IRequest<AccountDto>
    {
        public string AccountNumber { get; set; }
    }
}
