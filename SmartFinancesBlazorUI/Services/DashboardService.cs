using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Admin;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Pages.Dashboard;
using SmartFinancesBlazorUI.Services.Base;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace SmartFinancesBlazorUI.Services
{
    public class DashboardService : BaseHttpService, IDashboardService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRequestService _accountRequestService;
        private readonly IAccountService _accountService;
        private readonly ITransfersService _transfersService;

        public DashboardService(IClient client, ILocalStorageService localStorage, IMapper mapper,
                                IAccountRequestService accountRequestService, IAccountService accountService, ITransfersService transfersService)
                                : base(client, localStorage)
        {
            _mapper = mapper;
            _accountRequestService = accountRequestService;
            _accountService = accountService;
            _transfersService = transfersService;
        }

        public List<TransactionalAccountVM> UserAccounts { get; set; } = new List<TransactionalAccountVM>();
        public SavingsAccountVM? SavingsAccount { get; set; }

        public async Task<DashboardVM> LoadDashboardVM()
        {
            UserAccounts = await GetTransactionalAccountsAsync();
            var sortedAccounts = UserAccounts.OrderBy(q => q.Type).ToList();

            var currentAccount = await LoadCurrentAccountAsync();

            SavingsAccount = await GetSavingsAccountAsync();
            
            return new DashboardVM()
            {
                Accounts = sortedAccounts,
                CurrentAccount = currentAccount,
                SavingsAccount = this.SavingsAccount
            };
        }

        public async Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync()
        {
            return await _accountService.GetTransactionalAccountsAsync();
        }

        public async Task<SavingsAccountVM> GetSavingsAccountAsync()
        {
            return await _accountService.GetSavingsAccountAsync();
        }

        public async Task<List<string>> GetUsersPendingAccountTypes()
        {
            var pendingRequests = await _accountRequestService.GetByUserAndStatusAsync(Constants.STATUS_PENDING);

            var pendingAccountTypes = pendingRequests.Select(q => q.AccountType).ToList();

            return pendingAccountTypes;
        }

        public async Task<bool> AddFundsAsync(AddFundsVM addFundsVM)
        {
            var account = await GetChangedAccountAsync();

            account.Balance += addFundsVM.Amount;

            var updateAccountDto = new UpdateTransactionalAccountDto
            {
                Id = account.Id,
                Balance = account.Balance
            };

            await _accountService.UpdateTransactionalAccountAsync(updateAccountDto);

            return true;
        }

        public async Task ChangeAccountAsync(string accountNumber)
        {
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, accountNumber);
        }

        public async Task RequestNewAccountAsync(string accountType)
        {
            await _accountRequestService.CreateAsync(accountType);
        }

        public async Task<WithdrawVM> LoadWithdrawVM()
        {
            var currentAccount = await LoadCurrentAccountAsync();

            return new WithdrawVM()
            {
                TransactionalAccount = currentAccount,
                SavingsAccount = this.SavingsAccount
            };
        }

        public async Task<bool> WithdrawFromSavingsAccountAsync(WithdrawVM withdrawVM)
        {
            var transferDto = await GetSavingsAccountTransferDto(withdrawVM.Amount, Constants.WITHDRAW);

            await _transfersService.WithdrawFromSavingsAccountAsync(transferDto);

            return true;
        }

        public async Task<DepositVM> LoadDepositVM()
        {
            var currentAccount = await LoadCurrentAccountAsync();

            return new DepositVM()
            {
                TransactionalAccount = currentAccount,
                SavingsAccount = this.SavingsAccount
            };
        }

        public async Task<bool> DepositOnSavingsAccountAsync(DepositVM depositVM)
        {
            var transferDto = await GetSavingsAccountTransferDto(depositVM.Amount, Constants.DEPOSIT);

            await _transfersService.DepositOnSavingsAccountAsync(transferDto);

            return true;
        }


        private async Task<TransactionalAccountVM> LoadCurrentAccountAsync()
        {
            bool isCurrentAccountSet = await _localStorage.ContainKeyAsync(Constants.CURRENTACCOUNT);

            if (!isCurrentAccountSet)
            {
                return await GetMainAccountAsync();
            }

            var accountNumber = await GetCurrentAccountNumberAsync();

            return await _accountService.GetTransactionalAccountByNumberAsync(accountNumber);
        }

        private async Task<TransactionalAccountVM> GetMainAccountAsync()
        {
            var account = UserAccounts.FirstOrDefault(q => q.Type == AccountType.Main);
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
            var currentAccount = await LoadCurrentAccountAsync();

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
