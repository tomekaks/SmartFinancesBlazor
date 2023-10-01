using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.BudgetPlanner
{
    public class EditExpenseVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid type")]
        public int ExpenseTypeId { get; set; }
        public List<ExpenseTypeVM> ExpenseTypes { get; set; }
    }
}
