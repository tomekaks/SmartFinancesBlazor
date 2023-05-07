using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Contact.Requests.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }
}
