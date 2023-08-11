﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Accounts.Dtos
{
    public class UpdateAccountDto
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Budget { get; set; }
    }
}
