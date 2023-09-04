using SmartFinancesBlazorUI.Models.Enum;
using System.ComponentModel;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class AddExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeVM Type { get; set; }
        [DisplayName("Regular expense")]
        public bool IsRegular { get; set; }
    }
}
