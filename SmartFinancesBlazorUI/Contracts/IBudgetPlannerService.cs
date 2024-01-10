using SmartFinancesBlazorUI.Models.BudgetPlanner;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IBudgetPlannerService
    {
        Task<PlannerVM> GetPlannerVMAsync();
        Task<SetBudgetVM> GetBudgetVMAsync();
        Task<bool> SetBudgetAsync(SetBudgetVM setBudgetVM);
        Task<bool> SetBudgetAsync(decimal budget);
        Task<EditExpenseVM> GetExpenseAsync(int id);
        Task<List<RegularExpenseVM>> GetRegularExpensesAsync();
        Task<EditRegularExpenseVM> GetRegularExpenseAsync(int id);
        Task<List<ExpenseTypeVM>> GetExpenseTypesAsync();
        Task<bool> AddExpenseAsync(AddExpenseVM addExpenseVM);
        Task<bool> EditExpenseAsync(EditExpenseVM editExpenseVM);
        Task<bool> EditExpenseAsync(ExpenseVM expenseVM);
        Task<bool> DeleteExpenseAsync(int id);
        Task<bool> AddRegularExpenseAsync(AddRegularExpenseVM addRegularExpenseVM);
        Task<bool> EditRegularExpenseAsync(EditRegularExpenseVM editRegularExpenseVM);
        Task<bool> DeleteRegularExpenseAsync(int id);
        Task<YearlySummaryVM> GetYearlySummaryAsync();
        Task StartNewYearlySummary();
        Task<MonthlySummaryVM> GetMonthlySummaryAsync(int id);
        Task<List<MonthlySummaryVM>> GetMonthlySummariesByYearAsync(int yearlySummaryId);
        public void MoveMonthForward();
        public void MoveMonthBack();
    }
}
