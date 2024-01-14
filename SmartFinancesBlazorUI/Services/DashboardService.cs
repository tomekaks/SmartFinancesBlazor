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
        public DashboardService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public List<AccountVM> UserAccounts { get; set; } = new List<AccountVM>();

        public async Task<DashboardVM> LoadDashboardVM()
        {
            UserAccounts = await GetAllAccountsAsync();
            var sortedAccounts = UserAccounts.OrderBy(q => q.Type).ToList();

            var currentAccount = await LoadCurrentAccountAsync();
            
            return new DashboardVM()
            {
                Accounts = sortedAccounts,
                CurrentAccount = currentAccount
            };
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

        private async Task<List<AccountVM>> GetAllAccountsAsync()
        {
            await AddBearerToken();
            var accountsDto = await _client.AccountsGetAllAsync();

            if (accountsDto is null || accountsDto.Count == 0)
            {
                throw new Exception("Something went wrong");
            }

            return _mapper.Map<List<AccountVM>>(accountsDto);
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
