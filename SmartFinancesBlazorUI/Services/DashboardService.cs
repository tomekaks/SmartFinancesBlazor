using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace SmartFinancesBlazorUI.Services
{
    public class DashboardService : BaseHttpService, IDashboardService
    {
        private readonly IMapper _mapper;
        private readonly ITransfersService _transfersService;
        public DashboardService(IClient client, ILocalStorageService localStorage, IMapper mapper, ITransfersService transfersService) 
                                : base(client, localStorage)
        {
            _mapper = mapper;
            _transfersService = transfersService;
        }

        public List<AccountVM> UserAccounts { get; set; } = new List<AccountVM>();
        public AccountVM? SavingsAccount { get; set; }

        public async Task<DashboardVM> LoadDashboardVM()
        {
            UserAccounts = await GetAllAccountsAsync();
            var sortedAccounts = UserAccounts.OrderBy(q => q.Type).ToList();

            var currentAccount = await LoadCurrentAccountAsync();

            SavingsAccount = await LoadSavingsAccountAsync();
            
            return new DashboardVM()
            {
                Accounts = sortedAccounts,
                CurrentAccount = currentAccount
            };
        }

        public async Task<List<AccountVM>> GetAllAccountsAsync()
        {
            await AddBearerToken();
            var accountsDto = await _client.AccountsGetAllAsync();

            if (accountsDto is null || accountsDto.Count == 0)
            {
                throw new Exception("Something went wrong");
            }

            return _mapper.Map<List<AccountVM>>(accountsDto);
        }

        public async Task<bool> AddFundsAsync(AddFundsVM addFundsVM)
        {
            var account = await GetChangedAccountAsync();

            account.Balance += addFundsVM.Amount;

            var updateAccountDto = new UpdateAccountDto
            {
                Id = account.Id,
                Balance = account.Balance
            };

            await AddBearerToken();
            await _client.AccountsPUTAsync(updateAccountDto);

            return true;
        }

        public async Task ChangeAccountAsync(string accountNumber)
        {
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, accountNumber);
        }

        public async Task<bool> RequestNewAccountAsync(NewAccountVM newAccountVM)
        {
            return true;
        }

        public async Task<bool> RequestNewAccountAsync(int accountType)
        {
            var accountDto = new CreateAccountDto() { Type = accountType };

            await AddBearerToken();
            await _client.AccountsPOSTAsync(accountDto);

            return true;
        }

        public async Task<WithdrawVM> LoadWithdrawVM()
        {
            var currentAccount = await LoadCurrentAccountAsync();

            return new WithdrawVM()
            {
                Account = currentAccount,
                SavingsAccount = this.SavingsAccount
            };
        }

        public async Task<bool> WithdrawFromSavingsAccountAsync(WithdrawVM withdrawVM)
        {
            var transferDto = new CreateTransferDto()
            {
                Amount = withdrawVM.Amount,
                ReceiverAccountNumber = await GetCurrentAccountNumberAsync(),
                SenderAccountNumber = SavingsAccount.Number,
                SendTime = DateTime.UtcNow,
                Title = "Withdraw"
            };

            await AddBearerToken();
            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

        public async Task<DepositVM> LoadDepositVM()
        {
            var currentAccount = await LoadCurrentAccountAsync();

            return new DepositVM()
            {
                Account = currentAccount,
                SavingsAccount = this.SavingsAccount
            };
        }

        public async Task<bool> DepositOnSavingsAccountAsync(DepositVM depositVM)
        {
            var transferDto = new CreateTransferDto()
            {
                Amount = depositVM.Amount,
                SenderAccountNumber = await GetCurrentAccountNumberAsync(),
                ReceiverAccountNumber = SavingsAccount.Number,
                SendTime = DateTime.UtcNow,
                Title = "Deposit"
            };

            await AddBearerToken();
            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }


        private async Task<AccountVM> LoadCurrentAccountAsync()
        {
            bool isCurrentAccountSet = await _localStorage.ContainKeyAsync(Constants.CURRENTACCOUNT);

            if (!isCurrentAccountSet)
            {
                return await GetMainAccountAsync();
            }

            var accountDto = await GetAccountAsync();
            return _mapper.Map<AccountVM>(accountDto);
        }

        private async Task<AccountVM> LoadSavingsAccountAsync()
        {
            var savingsAccount = UserAccounts.FirstOrDefault(q => q.Type == AccountType.Savings);

            if (savingsAccount == null)
            {
                return null;
            }

            await _localStorage.SetItemAsync(Constants.SAVINGSACCOUNT, savingsAccount);
            return savingsAccount;
        }

        private async Task<AccountVM> GetMainAccountAsync()
        {
            var account = UserAccounts.FirstOrDefault(q => q.Type == AccountType.Main);
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, account.Number);

            return account;
        }

        private async Task<AccountVM> GetChangedAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();
            var account = UserAccounts.FirstOrDefault(q => q.Number == accountNumber);

            if (account == null)
            {
                throw new Exception("Something went wrong");
            }

            return account;
        }

        private async Task<AccountDto> GetAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            var accountDto = await _client.AccountsGetByNumberAsync(accountNumber);

            if (accountDto == null)
            {
                throw new Exception("Something went wrong");
            }

            return accountDto;
        }



        //public async Task<AccountVM> LoadCurrentAccountAsync()
        //{
        //    bool isCurrentAccountSet = await _localStorage.ContainKeyAsync(Constants.CURRENTACCOUNT);

        //    if (!isCurrentAccountSet)
        //    {
        //        return await GetMainAccountAsync();
        //    }

        //    var accountDto = await GetAccountAsync();
        //    return _mapper.Map<AccountVM>(accountDto);
        //}

        //public async Task<AccountVM> GetMainAccountAsync()
        //{
        //    await AddBearerToken();
        //    var account = await _client.AccountsGetMainAccountAsync();
        //    await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, account.Number);

        //    return _mapper.Map<AccountVM>(account);
        //}

        //public async Task<bool> AddFundsAsync(AddFundsVM addFundsVM)
        //{
        //    var accountDto = await GetAccountAsync();

        //    accountDto.Balance += addFundsVM.Amount;
        //    var updateAccountDto = new UpdateAccountDto
        //    {
        //        Id = accountDto.Id,
        //        Balance = accountDto.Balance
        //    };

        //    await AddBearerToken();
        //    await _client.AccountsPUTAsync(updateAccountDto);

        //    return true;
        //}
    }
}
