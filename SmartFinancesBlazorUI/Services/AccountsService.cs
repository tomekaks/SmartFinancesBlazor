using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Accounts;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AccountsService : BaseHttpService, IAccountsService
    {
        private readonly IMapper _mapper;
        public AccountsService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<AccountVM>> GetAllAccountsAsync()
        {
            await AddBearerToken();
            var accoutsDto = await _client.AccountsGetAllAsync();

            if (accoutsDto == null)
            {
                throw new Exception("Something went wrong");
            }

            var orderedAccounts = accoutsDto.OrderBy(q => q.Type);

            var accounts = _mapper.Map<List<AccountVM>>(orderedAccounts);

            return accounts;
        }

        public async Task ChangeAccountAsync(string accountNumber)
        {
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, accountNumber);
        }

        public async Task<bool> RequestNewAccountAsync(NewAccountVM newAccountVM)
        {

            return true;   
        }
    }
}
