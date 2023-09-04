﻿using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Core.Enums;

namespace SmartFinances.Application.Features.Expenses.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
        public bool IsRegular { get; set; }
    }
}
