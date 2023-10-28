using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Accounts;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;
using System.Reflection.Metadata;

namespace SmartFinancesBlazorUI.Services
{
    public class DashboardService : BaseHttpService, IDashboardService
    {
        private readonly IMapper _mapper;
        public DashboardService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<AccountVM> GetMainAccountAsync()
        {
            await AddBearerToken();
            var account = await _client.AccountsGetMainAccountAsync();
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, account.Number);

            return _mapper.Map<AccountVM>(account);
        }

        public async Task<bool> AddFundsAsync(AddFundsVM addFundsVM)
        {
            var accountDto = await GetAccountAsync();

            accountDto.Balance += addFundsVM.Amount;
            var updateAccountDto = new UpdateAccountDto
            {
                Id = accountDto.Id,
                Balance = accountDto.Balance
            };

            await AddBearerToken();
            await _client.AccountsPUTAsync(updateAccountDto);

            return true;
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
    }
}
