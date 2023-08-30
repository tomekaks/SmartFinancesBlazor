using SmartFinancesBlazorUI.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class EditRegularExpenseVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public ExpenseType Type { get; set; }
    }
}
