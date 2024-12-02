using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class DashboardService : BaseHttpService, IDashboardService
    {
        private readonly IAccountRequestService _accountRequestService;
        private readonly IAccountsService _accountsService;
        private readonly ITransfersService _transfersService;
        private readonly IAccountTypesService _accountTypesService;

        public DashboardService(IClient client, ILocalStorageService localStorage,
                                IAccountRequestService accountRequestService, IAccountsService accountsService, 
                                ITransfersService transfersService, IAccountTypesService accountTypesService)
                                : base(client, localStorage)
        {
            _accountRequestService = accountRequestService;
            _accountsService = accountsService;
            _transfersService = transfersService;
            _accountTypesService = accountTypesService;
        }

        public List<TransactionalAccountVM> UserAccounts { get; set; } = new List<TransactionalAccountVM>();
        public SavingsAccountVM? SavingsAccount { get; set; }

        public async Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync()
        {
            var userAccounts = await _accountsService.GetUsersTransactionalAccountsAsync();
            UserAccounts = userAccounts;

            bool isCurrentAccountSet = await _localStorage.ContainKeyAsync(Constants.CURRENTACCOUNT);

            if (!isCurrentAccountSet)
            {
                await SetMainAccountAsCurrentAsync();
            }

            return userAccounts;
        }

        public async Task<SavingsAccountVM> GetSavingsAccountAsync()
        {
            var savingsAccount = await _accountsService.GetUsersSavingsAccountAsync();
            SavingsAccount = savingsAccount;

            return savingsAccount;
        }

        public async Task<List<string>> GetUsersPendingAccountTypesAsync()
        {
            var pendingRequests = await _accountRequestService.GetByUserAndStatusAsync(Constants.STATUS_PENDING);

            var pendingAccountTypes = pendingRequests.Select(q => q.AccountTypeVM.Name).ToList();

            return pendingAccountTypes;
        }

        public async Task<List<AccountTypeVM>> GetAccountTypesAsync()
        {
            var accountTypes = await _accountTypesService.GetAllAsync();
            return accountTypes;
        }

        public async Task<TransactionalAccountVM> GetCurrentAccountAsync()
        {
            var currentAccount = await _accountsService.GetCurrentAccountAsync();
            return currentAccount;
        }

        public async Task<bool> AddFundsAsync(int accountId, decimal funds)
        {
            var account = GetTransactionalAccountById(accountId);

            account.Balance += funds;

            await _accountsService.UpdateTransactionalAccountAsync(accountId, account.Balance);

            return true;
        }

        public async Task ChangeAccountAsync(string accountNumber)
        {
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, accountNumber);
        }

        public async Task RequestNewAccountAsync(AccountTypeVM accountType)
        {
            await _accountRequestService.CreateAsync(accountType);
        }

        public async Task SetSavingsGoalAsync(decimal goal)
        {
            var updateSavingsAccount = new UpdateSavingsGoalDto()
            {
                Id = SavingsAccount.Id,
                Goal = goal
            };

            await _client.SavingsAccountsPUTAsync(updateSavingsAccount);
        }

        private async Task SetMainAccountAsCurrentAsync()
        {
            var account = UserAccounts.FirstOrDefault(q => q.Type == Constants.ACCOUNTTYPE_MAIN);
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, account.Number);
        }

        private TransactionalAccountVM GetTransactionalAccountById(int accountId)
        {
            var account = UserAccounts.FirstOrDefault(q => q.Id == accountId);
            if (account == null)
            {
                throw new Exception("Something went wrong");
            }

            return account;
        }
    }
}
