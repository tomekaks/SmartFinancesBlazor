﻿using MediatR;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.ExpenseTypes.Requests.Commands
{
    public class UpdateExpenseTypeCommand : IRequest
    {
        public EditExpenseTypeDto EditExpenseTypeDto { get; set; }
    }
}
