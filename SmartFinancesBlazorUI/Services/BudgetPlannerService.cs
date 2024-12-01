using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.BudgetPlanner;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class BudgetPlannerService : BaseHttpService, IBudgetPlannerService
    {
        private readonly IMapper _mapper;
        public BudgetPlannerService(IClient client, IMapper mapper, 
                                    ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<YearlySummaryVM> GetYearlySummaryAsync(int currentAccountId, int currentYear)
        {
            try
            {
                var yearlySummaryDto = await _client.YearlySummariesGETAsync(currentAccountId, currentYear);

                var yearlySummaryVM = _mapper.Map<YearlySummaryVM>(yearlySummaryDto);
                return yearlySummaryVM;
            }
            catch (ApiException ex) when (ex.StatusCode == 404)
            {
                return null;
            }
        }

        public async Task StartNewYearlySummary(int currentAccountId, int currentYear)
        {
            var createYearlySummaryDto = new CreateYearlySummaryDto()
            {
                TransactionalAccountId = currentAccountId,
                Year = currentYear,
            };

            await _client.YearlySummariesPOSTAsync(createYearlySummaryDto);
        }

        public async Task<MonthlySummaryVM> GetMonthlySummaryAsync(int id)
        {
            var monthlySumaryDto = await _client.MonthlySummariesGETAsync(id);

            var monthlySummaryVM = _mapper.Map<MonthlySummaryVM>(monthlySumaryDto);
            return monthlySummaryVM;
        }

        public async Task<bool> SetBudgetAsync(int monthlySummaryId, decimal budget)
        {
            var updateDto = new UpdateMonthlySummaryDto()
            {
                Id = monthlySummaryId,
                Budget = budget
            };
            await _client.MonthlySummariesPUTAsync(updateDto);

            return true;
        }  

        public async Task<List<RegularExpenseVM>> GetRegularExpensesAsync(int currentAccountId)
        {
            var regularExpensesDto = await _client.RegularExpensesAllAsync(currentAccountId);

            if (regularExpensesDto == null || regularExpensesDto.Count < 1)
            {
                return new List<RegularExpenseVM>();
            }

            return _mapper.Map<List<RegularExpenseVM>>(regularExpensesDto);
        }

        public async Task<List<ExpenseTypeVM>> GetExpenseTypesAsync()
        {
            var expenseTypesDto = await _client.ExpenseTypesAllAsync();

            if (expenseTypesDto == null || !expenseTypesDto.Any())
            {
                return new List<ExpenseTypeVM>();
            }

            return _mapper.Map<List<ExpenseTypeVM>>(expenseTypesDto);
        }

        public async Task<bool> AddExpenseAsync(AddExpenseVM addExpenseVM)
        {
            var expenseDto = new ExpenseDto()
            {
                Name = addExpenseVM.Name,
                Amount = addExpenseVM.Amount,
                ExpenseTypeId = addExpenseVM.ExpenseTypeId,
                MonthlySummaryId = addExpenseVM.MonthlySummaryId,
                IsRegular = addExpenseVM.IsRegular
            };

            await _client.ExpensesPOSTAsync(expenseDto);

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
            var regularExpenseDto = new RegularExpenseDto()
            {
                Name = addRegularExpenseVM.Name,
                Amount = addRegularExpenseVM.Amount,
                ExpenseTypeId = addRegularExpenseVM.ExpenseTypeId,
                TransactionalAccountId = addRegularExpenseVM.CurrentAccountId
            };

            await _client.RegularExpensesPOSTAsync(regularExpenseDto);

            return true;
        }

        public async Task<bool> AddRegularExpenseAsync(AddExpenseVM addExpenseVM, int currentAccountId)
        {
            var regularExpenseDto = new RegularExpenseDto()
            {
                Name = addExpenseVM.Name,
                Amount = addExpenseVM.Amount,
                ExpenseTypeId = addExpenseVM.ExpenseTypeId,
                TransactionalAccountId = currentAccountId
            };
            await _client.RegularExpensesPOSTAsync(regularExpenseDto);

            return true;
        }

        public async Task<bool> EditRegularExpenseAsync(RegularExpenseVM regularExpenseVM)
        {
            var regularExpenseDto = _mapper.Map<EditRegularExpenseDto>(regularExpenseVM);
            await _client.RegularExpensesPUTAsync(regularExpenseDto);

            return true;
        }

        public async Task UseRegularExpenseAsync(RegularExpenseVM regularExpenseVM, int monthlySummaryId)
        {
            var expenseDto = new ExpenseDto()
            {
                Name = regularExpenseVM.Name,
                Amount = regularExpenseVM.Amount,
                ExpenseTypeId = regularExpenseVM.ExpenseTypeVM.Id,
                MonthlySummaryId = monthlySummaryId
            };
            await _client.ExpensesPOSTAsync(expenseDto);
        }

        public async Task<bool> DeleteRegularExpenseAsync(int id)
        {
            await _client.RegularExpensesDELETEAsync(id);

            return true;
        }
    }
}
