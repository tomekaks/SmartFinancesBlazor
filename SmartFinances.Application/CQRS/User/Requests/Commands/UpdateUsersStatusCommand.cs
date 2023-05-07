using MediatR;
using SmartFinances.Application.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.User.Requests.Commands
{
    public class UpdateUsersStatusCommand : IRequest
    {
        public UsersStatusDto UsersStatusDto{ get; set; }
    }
}
