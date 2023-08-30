using SmartFinancesBlazorUI.Models.BudgetPlanner;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IBudgetPlannerService
    {
        Task<PlannerVM> GetPlannerVM();
        Task<bool> AddExpense(AddExpenseVM addExpenseVM);
        Task<bool> EditExpense(EditExpenseVM editExpenseVM);
        Task<bool> EditRegularExpense(EditRegularExpenseVM editRegularExpenseVM);
    }
}
