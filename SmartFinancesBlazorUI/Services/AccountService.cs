using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AccountService : BaseHttpService, IAccountService
    {
        private readonly IMapper _mapper;

        public AccountService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task CreateSavingsAccountAcync()
        {
            await AddBearerToken();
            await _client.SavingsAccountsPOSTAsync();
        }

        public async Task CreateTransactionalAccountAsync(string accountType)
        {
            var accountDto = new CreateTransactionalAccountDto() { Type = accountType };

            await AddBearerToken();
            await _client.TransactionalAccountsPOSTAsync(accountDto);
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

        public async Task<TransactionalAccountVM> GetTransactionalAccountByNumberAsync(string accountNumber)
        {
            await AddBearerToken();
            var accountDto = await _client.TransactionalAccountsGetByNumberAsync(accountNumber);

            if (accountDto == null)
            {
                throw new Exception("Something went wrong");
            }

            return _mapper.Map<TransactionalAccountVM>(accountDto);
        }

        public async Task<List<TransactionalAccountVM>> GetTransactionalAccountsAsync()
        {
            await AddBearerToken();
            var accountsDto = await _client.TransactionalAccountsGetAllAsync();

            if (accountsDto is null || accountsDto.Count == 0)
            {
                throw new Exception("Something went wrong");
            }

            var transactionalAccounts = _mapper.Map<List<TransactionalAccountVM>>(accountsDto);

            return transactionalAccounts;
        }

        public async Task UpdateTransactionalAccountAsync(UpdateTransactionalAccountDto accountDto)
        {
            await AddBearerToken();
            await _client.TransactionalAccountsPUTAsync(accountDto);
        }
    }
}
