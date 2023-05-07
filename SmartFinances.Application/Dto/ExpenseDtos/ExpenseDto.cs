using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto.ExpenseDtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto Type { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
        public bool IsRegular { get; set; }
    }
}
