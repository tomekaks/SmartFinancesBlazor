using MediatR;
using SmartFinances.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Users.Requests.Commands
{
    public class UpdateUsersStatusCommand : IRequest
    {
        public UsersStatusDto UsersStatusDto { get; set; }
    }
}
