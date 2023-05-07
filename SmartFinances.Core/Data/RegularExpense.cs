using SmartFinances.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Core.Data
{
    public class RegularExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
