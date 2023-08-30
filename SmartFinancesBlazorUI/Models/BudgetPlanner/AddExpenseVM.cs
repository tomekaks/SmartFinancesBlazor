using SmartFinancesBlazorUI.Models.Enum;
using System.ComponentModel;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class AddExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType Type { get; set; }
        [DisplayName("Regular expense")]
        public bool IsRegular { get; set; }
    }
}
