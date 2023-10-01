using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class AddExpenseVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid type")]
        public int ExpenseTypeId { get; set; }
        public List<ExpenseTypeVM> ExpenseTypes { get; set; } = new List<ExpenseTypeVM>();
        [DisplayName("Regular expense")]
        public bool IsRegular { get; set; }
    }
}
