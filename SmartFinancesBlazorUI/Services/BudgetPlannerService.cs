using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class BudgetPlannerService : BaseHttpService, IBudgetPlannerService
    {
        private readonly IMapper _mapper;
        public BudgetPlannerService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {
            _mapper = mapper;
        }

        public AccountVM CurrentAccount { get; set; } = new();

        public async Task<PlannerVM> GetPlannerVM()
        {
            CurrentAccount = await GetAccount();
            var expenses = await GetExpenses();           

            return new PlannerVM()
            {
                Expenses = expenses,
                Budget = CurrentAccount.Budget
            };
        }

        public async Task<bool> SetBudget(SetBudgetVM setBudgetVM)
        {
            var updateAccount = new UpdateAccountDto()
            {
                Id = CurrentAccount.Id,
                Budget = setBudgetVM.Budget
            };

            await AddBearerToken();
            await _client.AccountsPUTAsync(updateAccount);

            return true;
        }

        public async Task<List<ExpenseVM>> GetExpenses()
        {
            await AddBearerToken();
            var expensesDto = await _client.ExpensesAllAsync(CurrentAccount.Id);

            if (expensesDto == null)
            {
                return new List<ExpenseVM>();
            }

            return _mapper.Map<List<ExpenseVM>>(expensesDto);
        }
        
        public async Task<EditExpenseVM> GetExpense(int id)
        {
            await AddBearerToken();
            var expenseDto = await _client.ExpensesGETAsync(id);

            if (expenseDto == null)
            {
                return new EditExpenseVM();
            }

            return _mapper.Map<EditExpenseVM>(expenseDto);
        }

        public async Task<bool> AddExpense(AddExpenseVM addExpenseVM)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(addExpenseVM);
            expenseDto.AccountId = CurrentAccount.Id;

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

        public async Task<bool> DeleteExpense(int id)
        {
            await _client.ExpensesDELETEAsync(id);

            return true;
        }

        public async Task<bool> AddRegularExpense(AddRegularExpenseVM addRegularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(addRegularExpenseVM);
            regularExpenseDto.AccountId = CurrentAccount.Id;

            await AddBearerToken();
            await _client.RegularExpensesPOSTAsync(regularExpenseDto);

            return true;
        }

        public async Task<bool> EditRegularExpense(EditRegularExpenseVM editRegularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(editRegularExpenseVM);

            await AddBearerToken();
            await _client.RegularExpensesPUTAsync(regularExpenseDto);

            return true;
        }

        private async Task<AccountVM> GetAccount()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            var accountDto = await _client.AccountsGetByNumberAsync(accountNumber);

            var accountVM = _mapper.Map<AccountVM>(accountDto);

            return accountVM ?? new AccountVM();
        }
    }
}
