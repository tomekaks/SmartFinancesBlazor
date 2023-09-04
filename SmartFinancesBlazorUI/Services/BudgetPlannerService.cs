using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class BudgetPlannerService : BaseHttpService ,IBudgetPlannerService
    {
        private readonly IMapper _mapper;
        private int _accountId;
        private string _accountNumber;
        public BudgetPlannerService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {
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

            var updateAccount = new UpdateAccountDto()
            {
                Id = account.Id,
                Budget = setBudgetVM.Budget
            };

            await AddBearerToken();
            await _client.AccountsPUTAsync(updateAccount);

            return true;
        }

        private async Task<List<ExpenseDto>> GetExpenses()
        {
            await AddBearerToken();
            var expenses = await _client.ExpensesAllAsync(_accountId);

            return expenses.ToList() ?? new List<ExpenseDto>();
        }

        private async Task<AccountDto> GetAccount()
        {

            //TODO

            await AddBearerToken();
            var account = await _client.AccountsGET2Async(_accountNumber);

            return account ?? new AccountDto();
        }

        public async Task<bool> AddExpense(AddExpenseVM addExpenseVM)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(addExpenseVM);

            await AddBearerToken();
            await _client.ExpensesPOSTAsync(expenseDto);

            return true;
        }

        public async Task<bool> EditExpense(EditExpenseVM editExpenseVM)
        {
            var expenseDto = _mapper.Map<EditExpenseDto>(editExpenseVM);

            await AddBearerToken();
            await _client.ExpensesPUTAsync(expenseDto);

            return true;
        }

        public async Task<bool> EditRegularExpense(EditRegularExpenseVM editRegularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(editRegularExpenseVM);

            await AddBearerToken();
            await _client.RegularExpensesPUTAsync(regularExpenseDto);

            return true;
        }
    }
}
