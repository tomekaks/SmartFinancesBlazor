using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Accounts;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Pages.BudgetPlanner;
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
        public YearlySummaryVM? CurrentYearlySummary { get; set; }
        public MonthlySummaryVM? CurrentMonthlySummary { get; set; }
        public int CurrentYear { get; set; } = DateTime.Now.Year;
        public int CurrentMonth { get; set; } = DateTime.Now.Month;

        public async Task<PlannerVM> GetPlannerVMAsync()
        {
            CurrentAccount = await GetAccountAsync();
            CurrentYearlySummary = await GetYearlySummaryAsync();

            if(CurrentYearlySummary == null)
            {
                return new PlannerVM();
            }

            CurrentMonthlySummary = SetCurrentMonthlySummary();

            return new PlannerVM()
            {
                YearlySummary = CurrentYearlySummary,
                CurrentMonthlySummary = this.CurrentMonthlySummary,
                Budget = CurrentMonthlySummary.Budget
            };

        }

        public async Task<YearlySummaryVM> GetYearlySummaryAsync()
        {
            try
            {
                await AddBearerToken();
                var yearlySummaryDto = await _client.YearlySummaryGETAsync(CurrentAccount.Id, CurrentYear);

                var yearlySummaryVM = _mapper.Map<YearlySummaryVM>(yearlySummaryDto);
                return yearlySummaryVM;
            }
            catch (ApiException ex) when (ex.StatusCode == 404)
            {
                return null;
            }
        }

        public async Task StartNewYearlySummary()
        {
            var createYearlySummaryDto = new CreateYearlySummaryDto()
            {
                Year = CurrentYear,
                AccountId = CurrentAccount.Id
            };

            await AddBearerToken();
            await _client.YearlySummaryPOSTAsync(createYearlySummaryDto);
        }

        public async Task<MonthlySummaryVM> GetMonthlySummaryAsync(int id)
        {
            await AddBearerToken();
            var monthlySumaryDto = await _client.MonthlySummaryGETAsync(id);

            var monthlySummaryVM = _mapper.Map<MonthlySummaryVM>(monthlySumaryDto);
            return monthlySummaryVM;
        }

        public async Task<List<MonthlySummaryVM>> GetMonthlySummariesByYearAsync(int yearlySummaryId)
        {
            await AddBearerToken();
            var monthlySummariesDto = await _client.MonthlySummaryGetByYearAsync(yearlySummaryId);

            var monthlySummariesVM = _mapper.Map<List<MonthlySummaryVM>>(monthlySummariesDto);
            return monthlySummariesVM;
        }

        public async Task<bool> SetBudgetAsync(decimal budget)
        {
            var updateDto = new UpdateMonthlySummaryDto()
            {
                Id = CurrentMonthlySummary.Id,
                Budget = budget
            };

            await AddBearerToken();
            await _client.MonthlySummaryPUTAsync(updateDto);

            return true;
        }

        public async Task<List<ExpenseVM>> GetExpensesAsync()
        {
            await AddBearerToken();
            var expensesDto = await _client.ExpensesAllAsync(CurrentMonthlySummary.Id);

            if (expensesDto == null)
            {
                return new List<ExpenseVM>();
            }

            return _mapper.Map<List<ExpenseVM>>(expensesDto);
        }
        
        public async Task<EditExpenseVM> GetExpenseAsync(int id)
        {
            await AddBearerToken();
            var expenseDto = await _client.ExpensesGETAsync(id);

            if (expenseDto == null)
            {
                return new EditExpenseVM();
            }

            return _mapper.Map<EditExpenseVM>(expenseDto);
        }

        public async Task<List<RegularExpenseVM>> GetRegularExpensesAsync()
        {
            await AddBearerToken();
            var regularExpensesDto = await _client.RegularExpensesAllAsync(CurrentAccount.Id);

            if (regularExpensesDto == null)
            {
                return new List<RegularExpenseVM>();
            }

            return _mapper.Map<List<RegularExpenseVM>>(regularExpensesDto);
        }

        public async Task<EditRegularExpenseVM> GetRegularExpenseAsync(int id)
        {
            await AddBearerToken();
            var regularExpenseDto = await _client.RegularExpensesGETAsync(id);

            if (regularExpenseDto == null)
            {
                return new EditRegularExpenseVM();
            }

            return _mapper.Map<EditRegularExpenseVM>(regularExpenseDto);
        }

        public async Task<List<ExpenseTypeVM>> GetExpenseTypesAsync()
        {
            await AddBearerToken();
            var expenseTypesDto = await _client.ExpenseTypesAllAsync();

            if (expenseTypesDto == null || !expenseTypesDto.Any())
            {
                return new List<ExpenseTypeVM>();
            }

            return _mapper.Map<List<ExpenseTypeVM>>(expenseTypesDto);
        }

        public async Task<bool> AddExpenseAsync(AddExpenseVM addExpenseVM)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(addExpenseVM);
            expenseDto.ExpenseTypeId = addExpenseVM.ExpenseTypeId;
            expenseDto.MonthlySummaryId = CurrentMonthlySummary.Id;

            await AddBearerToken();
            await _client.ExpensesPOSTAsync(expenseDto);

            return true;
        }

        public async Task<bool> EditExpenseAsync(EditExpenseVM editExpenseVM)
        {
            var expenseDto = _mapper.Map<EditExpenseDto>(editExpenseVM);

            await AddBearerToken();
            await _client.ExpensesPUTAsync(expenseDto);

            return true;
        }

        public async Task<bool> EditExpenseAsync(ExpenseVM expenseVM)
        {
            var editExpenseDto = new EditExpenseDto()
            {
                Id = expenseVM.Id,
                Name = expenseVM.Name,
                Amount = expenseVM.Amount,
                ExpenseTypeId = expenseVM.ExpenseTypeVM.Id
            };

            await AddBearerToken();
            await _client.ExpensesPUTAsync(editExpenseDto);

            return true;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            await _client.ExpensesDELETEAsync(id);

            return true;
        }

        public async Task<bool> AddRegularExpenseAsync(AddRegularExpenseVM addRegularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(addRegularExpenseVM);
            regularExpenseDto.AccountId = CurrentAccount.Id;

            await AddBearerToken();
            await _client.RegularExpensesPOSTAsync(regularExpenseDto);

            return true;
        }

        public async Task<bool> AddRegularExpenseAsync(AddExpenseVM addExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(addExpenseVM);
            regularExpenseDto.AccountId = CurrentAccount.Id;

            await AddBearerToken();
            await _client.RegularExpensesPOSTAsync(regularExpenseDto);

            return true;
        }

        public async Task<bool> EditRegularExpenseAsync(EditRegularExpenseVM editRegularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<EditRegularExpenseDto>(editRegularExpenseVM);

            await AddBearerToken();
            await _client.RegularExpensesPUTAsync(regularExpenseDto);

            return true;
        }

        public async Task<bool> EditRegularExpenseAsync(RegularExpenseVM regularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<EditRegularExpenseDto>(regularExpenseVM);

            await AddBearerToken();
            await _client.RegularExpensesPUTAsync(regularExpenseDto);

            return true;
        }

        public async Task UseRegularExpenseAsync(RegularExpenseVM regularExpenseVM)
        {
            var expenseDto = new ExpenseDto()
            {
                Name = regularExpenseVM.Name,
                Amount = regularExpenseVM.Amount,
                ExpenseTypeId = regularExpenseVM.ExpenseTypeVM.Id,
                MonthlySummaryId = CurrentMonthlySummary.Id
            };

            await AddBearerToken();
            await _client.ExpensesPOSTAsync(expenseDto);
        }

        public async Task<bool> DeleteRegularExpenseAsync(int id)
        {
            await _client.RegularExpensesDELETEAsync(id);

            return true;
        }

        public void MoveMonthForward()
        {
            if (CurrentMonth < 12)
            {
                CurrentMonth++;
            }
        }

        public void MoveMonthBack()
        {
            if (CurrentMonth > 1)
            {  
                CurrentMonth--;
            }
        }

        private async Task<AccountVM> GetAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            var accountDto = await _client.AccountsGetByNumberAsync(accountNumber);

            return _mapper.Map<AccountVM>(accountDto);
        }

        private MonthlySummaryVM SetCurrentMonthlySummary()
        {
            var currentMonthlySummary = CurrentYearlySummary.MonthlySummaries.FirstOrDefault(q => q.Month == CurrentMonth);
            if (currentMonthlySummary == null)
            {
                return new MonthlySummaryVM();
            }
            return currentMonthlySummary;
        }

    }
}
