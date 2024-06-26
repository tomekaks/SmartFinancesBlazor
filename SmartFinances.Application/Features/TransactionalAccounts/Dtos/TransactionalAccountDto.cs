﻿using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.Transfers.Dtos;
using SmartFinances.Application.Features.YearlySummaries.Dtos;

namespace SmartFinances.Application.Features.TransactionalAccounts.Dtos
{
    public class TransactionalAccountDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
        public AccountTypeDto AccountTypeDto { get; set; }
        public decimal Budget { get; set; }
        public DateTime DateOfCreation { get; set; }
        public List<TransferDto> Transfers { get; set; }
        public List<YearlySummaryDto> YearlySummaries { get; set; }
        public List<RegularExpenseDto> RegularExpenses { get; set; }
    }
}
