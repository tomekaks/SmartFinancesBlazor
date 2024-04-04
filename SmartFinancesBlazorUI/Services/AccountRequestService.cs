using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Admin;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AccountRequestService : BaseHttpService, IAccountRequestService
    {
        private readonly IMapper _mapper;

        public AccountRequestService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task CreateAsync(string accountType)
        {
            var accountRequestDto = new CreateAccountRequestDto { AccountType = accountType };

            await AddBearerToken();
            await _client.AccountRequestPOSTAsync(accountRequestDto);
        }

        public async Task UpdateAsync(int accountRequestId, string status)
        {
            var updateAccountRequestDto = new UpdateAccountRequestDto()
            {
                Id = accountRequestId,
                Status = status
            };

            await AddBearerToken();
            await _client.AccountRequestPUTAsync(updateAccountRequestDto);
        }

        public async Task<AccountRequestVM> GetByIdAsync(int accountRequestId)
        {
            var accountRequest = await _client.AccountRequestGETAsync(accountRequestId);

            return _mapper.Map<AccountRequestVM>(accountRequest);
        }

        public async Task<List<AccountRequestVM>> GetAllByStatusAsync(string status)
        {
            await AddBearerToken();
            var accountRequests = await _client.AccountRequestsGetByStatusAsync(status);

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestVM>();
            }

            return _mapper.Map<List<AccountRequestVM>>(accountRequests);
        }

        
    }
}
