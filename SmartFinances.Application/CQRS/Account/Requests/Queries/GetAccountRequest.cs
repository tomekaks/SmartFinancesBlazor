using MediatR;
using SmartFinances.Application.Dto.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Requests.Queries
{
    public class GetAccountRequest : IRequest<AccountDto>
    {
        public string UserId { get; set; }
    }
}
