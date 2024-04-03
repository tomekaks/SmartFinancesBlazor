using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AccountRequestService : BaseHttpService, IAccountRequestService
    {
        public AccountRequestService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public async Task CreateAccountRequest(string accountType)
        {
            var accountRequestDto = new CreateAccountRequestDto { AccountType = accountType };

            await AddBearerToken();
            await _client.AccountRequestPOSTAsync(accountRequestDto);
        }
    }
}
