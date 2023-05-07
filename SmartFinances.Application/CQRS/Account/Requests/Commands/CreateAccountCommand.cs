using MediatR;
using SmartFinances.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Requests.Commands
{
    public class CreateAccountCommand : IRequest
    {
        public string UserId { get; set; }
        public string AccountName { get; set; }
    }
}
