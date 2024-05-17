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
        private readonly IMapper _mapper;
        private readonly IAccountRequestService _accountRequestService;
        private readonly IAccountService _accountService;
        private readonly ITransfersService _transfersService;
        private readonly IAccountTypesService _accountTypesService;

        public DashboardService(IClient client, ILocalStorageService localStorage, IMapper mapper,
                                IAccountRequestService accountRequestService, IAccountService accountService, 
                                ITransfersService transfersService, IAccountTypesService accountTypesService)
                                : base(client, localStorage)
        {
            _mapper = mapper;
            _accountRequestService = accountRequestService;
            _accountService = accountService;
            _transfersService = transfersService;
            _accountTypesService = accountTypesService;
        }

        public List<TransactionalAccountVM> UserAccounts { get; set; } = new List<TransactionalAccountVM>();
        public SavingsAccountVM? SavingsAccount { get; set; }

        public async Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync()
        {
            var userAccounts = await _accountService.GetTransactionalAccountsAsync();
            UserAccounts = userAccounts;

            return userAccounts;
        }

        public async Task<SavingsAccountVM> GetSavingsAccountAsync()
        {
            var savingsAccount = await _accountService.GetSavingsAccountAsync();
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
            bool isCurrentAccountSet = await _localStorage.ContainKeyAsync(Constants.CURRENTACCOUNT);

            if (!isCurrentAccountSet)
            {
                return await GetMainAccountAsync();
            }

            var accountNumber = await GetCurrentAccountNumberAsync();

            return await _accountService.GetTransactionalAccountByNumberAsync(accountNumber);
        }

        public async Task<bool> AddFundsAsync(AddFundsVM addFundsVM)
        {
            var account = await GetChangedAccountAsync();

            account.Balance += addFundsVM.Amount;

            await _accountService.UpdateTransactionalAccountAsync(account.Id, account.Balance);

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

        public async Task<bool> WithdrawFromSavingsAccountAsync(WithdrawVM withdrawVM)
        {
            var transferDto = await GetSavingsAccountTransferDto(withdrawVM.Amount, Constants.WITHDRAW);

            await _transfersService.WithdrawFromSavingsAccountAsync(transferDto);

            return true;
        }

        public async Task<bool> DepositOnSavingsAccountAsync(DepositVM depositVM)
        {
            var transferDto = await GetSavingsAccountTransferDto(depositVM.Amount, Constants.DEPOSIT);

            await _transfersService.DepositOnSavingsAccountAsync(transferDto);

            return true;
        }

        public async Task SetSavingsGoalAsync(decimal goal)
        {
            var updateSavingsAccount = new UpdateSavingsAccountDto()
            {
                Id = SavingsAccount.Id,
                Goal = goal
            };

            await _client.SavingsAccountsPUTAsync(updateSavingsAccount);
        }

        private async Task<TransactionalAccountVM> GetMainAccountAsync()
        {
            var account = UserAccounts.FirstOrDefault(q => q.Type == Constants.ACCOUNTTYPE_MAIN);
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, account.Number);

            return account;
        }

        private async Task<TransactionalAccountVM> GetChangedAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();
            var account = UserAccounts.FirstOrDefault(q => q.Number == accountNumber);

            if (account == null)
            {
                throw new Exception("Something went wrong");
            }

            return account;
        }

        private async Task<SavingsAccountTransferDto> GetSavingsAccountTransferDto(decimal amount, string operation)
        {
            var currentAccount = await GetCurrentAccountAsync();

            return new SavingsAccountTransferDto()
            {
                Amount = amount,
                TransactionalAccountName = currentAccount.Name,
                TransactionalAccountNumber = currentAccount.Number,
                SavingsAccountName = SavingsAccount.Name,
                SavingsAccountNumber = SavingsAccount.Number,
                SendTime = DateTime.UtcNow,
                Title = operation
            };
        }
    }
}
