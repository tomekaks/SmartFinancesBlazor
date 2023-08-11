﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Contacts.Requests.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }
}
