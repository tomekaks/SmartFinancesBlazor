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

        public List<TransactionalAccountVM> UserAccounts { get; set; } = new List<TransactionalAccountVM>();
        public SavingsAccountVM? SavingsAccount { get; set; }

        public async Task<DashboardVM> LoadDashboardVM()
        {
            UserAccounts = await GetAllAccountsAsync();
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

        public async Task<List<TransactionalAccountVM>> GetAllAccountsAsync()
        {
            await AddBearerToken();
            var accountsDto = await _client.TransactionalAccountsGetAllAsync();

            if (accountsDto is null || accountsDto.Count == 0)
            {
                throw new Exception("Something went wrong");
            }

            return _mapper.Map<List<TransactionalAccountVM>>(accountsDto);
        }

        public async Task<SavingsAccountVM> GetSavingsAccountAsync()
        {
            try
            {
                await AddBearerToken();
                var savingsAccountDto = await _client.SavingsAccountsGETAsync();

                var savingsAccountVM = _mapper.Map<SavingsAccountVM>(savingsAccountDto);

                await _localStorage.SetItemAsync(Constants.SAVINGSACCOUNT, savingsAccountVM.Number);
                return savingsAccountVM;
            }
            catch (ApiException ex) when (ex.StatusCode == 404 || ex.StatusCode == 204)
            {
                return null;
            }
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

            await AddBearerToken();
            await _client.TransactionalAccountsPUTAsync(updateAccountDto);

            return true;
        }

        public async Task ChangeAccountAsync(string accountNumber)
        {
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, accountNumber);
        }

        public async Task<bool> RequestNewTransactionalAccountAsync(string accountType)
        {
            var accountDto = new CreateTransactionalAccountDto() { Type = accountType };

            await AddBearerToken();
            await _client.TransactionalAccountsPOSTAsync(accountDto);

            return true;
        }

        public async Task<bool> RequestNewSavingsAccountAsync()
        {
            await AddBearerToken();
            await _client.SavingsAccountsPOSTAsync();

            return true;
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
            var currentAccount = await LoadCurrentAccountAsync();

            var transferDto = new SavingsAccountTransferDto()
            {
                Amount = withdrawVM.Amount,
                TransactionalAccountName = currentAccount.Name,
                TransactionalAccountNumber = currentAccount.Number,
                SavingsAccountName = SavingsAccount.Name,
                SavingsAccountNumber = SavingsAccount.Number,
                SendTime = DateTime.UtcNow,
                Title = "Withdraw"
            };

            await AddBearerToken();
            await _client.TransfersWithdrawFromSavingsAccountAsync(transferDto);

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
            var currentAccount = await LoadCurrentAccountAsync();

            var transferDto = new SavingsAccountTransferDto()
            {
                Amount = depositVM.Amount,
                TransactionalAccountName = currentAccount.Name,
                TransactionalAccountNumber = currentAccount.Number,
                SavingsAccountName = SavingsAccount.Name,
                SavingsAccountNumber = SavingsAccount.Number,
                SendTime = DateTime.UtcNow,
                Title = "Deposit"
            };

            await AddBearerToken();
            await _client.TransfersDepositToSavingsAccountAsync(transferDto);

            return true;
        }


        private async Task<TransactionalAccountVM> LoadCurrentAccountAsync()
        {
            bool isCurrentAccountSet = await _localStorage.ContainKeyAsync(Constants.CURRENTACCOUNT);

            if (!isCurrentAccountSet)
            {
                return await GetMainAccountAsync();
            }

            var accountDto = await GetAccountAsync();
            return _mapper.Map<TransactionalAccountVM>(accountDto);
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

        private async Task<TransactionalAccountDto> GetAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            var accountDto = await _client.TransactionalAccountsGetByNumberAsync(accountNumber);

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
