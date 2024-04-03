using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Admin;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AdminService : BaseHttpService, IAdminService
    {
        private readonly IMapper _mapper;

        public AdminService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<AccountRequestVM>> GetPendingAccountRequestsAsync()
        {
            await AddBearerToken();
            var accountRequests = await _client.AccountRequestsGetByStatusAsync(Constants.STATUS_PENDING);

            if(accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestVM>();
            }

            return _mapper.Map<List<AccountRequestVM>>(accountRequests);
        }
    }
}
