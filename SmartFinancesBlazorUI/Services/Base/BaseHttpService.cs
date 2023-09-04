using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace SmartFinancesBlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorageService.ContainKeyAsync("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await
                    _localStorageService.GetItemAsync<string>("token"));
        }
    }
}
