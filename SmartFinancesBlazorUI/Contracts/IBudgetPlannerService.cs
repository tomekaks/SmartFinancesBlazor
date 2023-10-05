using SmartFinancesBlazorUI.Models.BudgetPlanner;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IBudgetPlannerService
    {
        Task<PlannerVM> GetPlannerVMAsync();
        Task<SetBudgetVM> GetBudgetVMAsync();
        Task<bool> SetBudgetAsync(SetBudgetVM setBudgetVM);
        Task<EditExpenseVM> GetExpenseAsync(int id);
        Task<List<RegularExpenseVM>> GetRegularExpensesAsync();
        Task<EditRegularExpenseVM> GetRegularExpenseAsync(int id);
        Task<List<ExpenseTypeVM>> GetExpenseTypesAsync();
        Task<bool> AddExpenseAsync(AddExpenseVM addExpenseVM);
        Task<bool> EditExpenseAsync(EditExpenseVM editExpenseVM);
        Task<bool> DeleteExpenseAsync(int id);
        Task<bool> AddRegularExpenseAsync(AddRegularExpenseVM addRegularExpenseVM);
        Task<bool> EditRegularExpenseAsync(EditRegularExpenseVM editRegularExpenseVM);
        Task<bool> DeleteRegularExpenseAsync(int id);
    }
}
