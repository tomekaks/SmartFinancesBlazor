using MediatR;
using SmartFinances.Application.Features.Accounts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Accounts.Requests.Commands
{
    public class UpdateAccountCommand : IRequest
    {
        public UpdateAccountDto UpdateAccountDto { get; set; }
    }
}
