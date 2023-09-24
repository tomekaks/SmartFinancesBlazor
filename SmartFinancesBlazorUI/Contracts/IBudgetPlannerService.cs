using SmartFinancesBlazorUI.Models.BudgetPlanner;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IBudgetPlannerService
    {
        Task<PlannerVM> GetPlannerVM();
        Task<bool> SetBudget(SetBudgetVM setBudgetVM);
        Task<EditExpenseVM> GetExpense(int id);
        Task<bool> AddExpense(AddExpenseVM addExpenseVM);
        Task<bool> EditExpense(EditExpenseVM editExpenseVM);
        Task<bool> DeleteExpense(int id);
        Task<bool> AddRegularExpense(AddRegularExpenseVM addRegularExpenseVM);
        Task<bool> EditRegularExpense(EditRegularExpenseVM editRegularExpenseVM);
    }
}
