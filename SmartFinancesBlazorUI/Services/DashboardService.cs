using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
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

        public async Task<AccountVM> GetAccountAsync()
        {
            await AddBearerToken();
            var account = await _client.AccountsGetMainAccountAsync();
            await _localStorage.SetItemAsync(Constants.CURRENTACCOUNT, account.Number);

            return _mapper.Map<AccountVM>(account);
        }
    }
}
