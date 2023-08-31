using AutoMapper;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class BudgetPlannerService : IBudgetPlannerService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public BudgetPlannerService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<PlannerVM> GetPlannerVM()
        {
            //var expenses = await GetExpenses();
            //var account = await GetAccount();

            var expenses = new List<ExpenseDto>();
           

            return new PlannerVM()
            {
                Expenses = expenses,
                Budget = 2000
            };
        }

        public async Task<bool> SetBudget(SetBudgetVM setBudgetVM)
        {
            var account = await GetAccount();
            account.Budget = setBudgetVM.Budget;

            var response = await _httpClient.PutAsJsonAsync("api/account", account);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }

        private async Task<List<ExpenseDto>> GetExpenses()
        {
            var request = await _httpClient.GetAsync("api/expenses/getall");

            if (!request.IsSuccessStatusCode)
            {
                return new List<ExpenseDto>();
            }

            var expenses = await request.Content.ReadFromJsonAsync<List<ExpenseDto>>();
            return expenses ?? new List<ExpenseDto>();
        }

        private async Task<AccountDto> GetAccount()
        {
            var request = await _httpClient.GetAsync("api/account");

            if (!request.IsSuccessStatusCode)
            {
                return new AccountDto();
            }

            var account = await request.Content.ReadFromJsonAsync<AccountDto>();
            return account ?? new AccountDto();
        }

        public async Task<bool> AddExpense(AddExpenseVM addExpenseVM)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(addExpenseVM);

            var response = await _httpClient.PostAsJsonAsync("api/expense", expenseDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }

        public async Task<bool> EditExpense(EditExpenseVM editExpenseVM)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(editExpenseVM);

            var response = await _httpClient.PutAsJsonAsync("api/expense", expenseDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }

        public async Task<bool> EditRegularExpense(EditRegularExpenseVM editRegularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(editRegularExpenseVM);

            var response = await _httpClient.PutAsJsonAsync("api/regularexpense", regularExpenseDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }
    }
}
