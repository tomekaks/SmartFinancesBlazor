using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto.RegularExpenseDtos
{
    public class RegularExpenseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto Type { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
    }
}
