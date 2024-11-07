using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.AccountTypes;
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

        public async Task CreateAsync(AccountTypeVM accountType)
        {
            var accountRequestDto = new CreateAccountRequestDto()
            {
                Type = accountType.Name,
                AccountTypeId = accountType.Id,
            };
            await _client.AccountRequestsPOSTAsync(accountRequestDto);
        }

        public async Task UpdateAsync(int accountRequestId, string status)
        {
            var updateAccountRequestDto = new UpdateAccountRequestDto()
            {
                Id = accountRequestId,
                Status = status
            };

            await _client.AccountRequestsPUTAsync(updateAccountRequestDto);
        }

        public async Task<AccountRequestVM> GetByIdAsync(int accountRequestId)
        {
            var accountRequest = await _client.AccountRequestsGETAsync(accountRequestId);

            return _mapper.Map<AccountRequestVM>(accountRequest);
        }

        public async Task<List<AccountRequestVM>> GetAllByStatusAsync(string status)
        {
            var accountRequests = await _client.AccountRequestsGetByStatusAsync(status);

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestVM>();
            }

            return _mapper.Map<List<AccountRequestVM>>(accountRequests);
        }

        public async Task<List<AccountRequestVM>> GetAllAsync()
        {
            var accountRequests = await _client.AccountRequestsAllAsync();

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestVM>();
            }

            return _mapper.Map<List<AccountRequestVM>>(accountRequests);
        }

        public async Task<List<AccountRequestVM>> GetByUserAndStatusAsync(string status)
        {
            var accountRequests = await _client.AccountRequestsGetByUserAndStatusAsync(status);

            if (accountRequests == null || !accountRequests.Any())
            {
                return new List<AccountRequestVM>();
            }

            var accountRequestsVM = _mapper.Map<List<AccountRequestVM>>(accountRequests);

            return accountRequestsVM;
        }

    }
}
