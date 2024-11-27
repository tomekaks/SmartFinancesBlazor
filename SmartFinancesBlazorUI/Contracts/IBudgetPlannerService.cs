using SmartFinancesBlazorUI.Models.BudgetPlanner;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IBudgetPlannerService
    {
        Task<bool> SetBudgetAsync(int monthlySummaryId, decimal budget);

        Task<List<RegularExpenseVM>> GetRegularExpensesAsync(int currentAccountId);
        Task<List<ExpenseTypeVM>> GetExpenseTypesAsync();

        Task<bool> AddExpenseAsync(AddExpenseVM addExpenseVM);
        Task<bool> EditExpenseAsync(ExpenseVM expenseVM);
        Task<bool> DeleteExpenseAsync(int id);

        Task<bool> AddRegularExpenseAsync(AddRegularExpenseVM addRegularExpenseVM);
        Task<bool> AddRegularExpenseAsync(AddExpenseVM addExpenseVM);
        Task<bool> EditRegularExpenseAsync(RegularExpenseVM regularExpenseVM);
        Task UseRegularExpenseAsync(RegularExpenseVM regularExpenseVM);
        Task<bool> DeleteRegularExpenseAsync(int id);

        Task<YearlySummaryVM> GetYearlySummaryAsync(int currentAccountId, int currentYear);
        Task StartNewYearlySummary(int currentAccountId, int currentYear);
        Task<MonthlySummaryVM> GetMonthlySummaryAsync(int id);
    }
}
