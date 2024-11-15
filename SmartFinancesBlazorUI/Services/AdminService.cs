using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Admin;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Headers;

namespace SmartFinancesBlazorUI.Services
{
    public class AdminService : BaseHttpService, IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRequestService _accountRequestService;
        private readonly IAccountsService _accountsService;

        public AdminService(IClient client, ILocalStorageService localStorage, IMapper mapper,
            IAccountRequestService accountRequestService, IAccountsService accountsService)
            : base(client, localStorage)
        {
            _mapper = mapper;
            _accountRequestService = accountRequestService;
            _accountsService = accountsService;
        }

        public async Task ApproveAccountRequestAsync(int accountRequestId)
        {
            await _accountRequestService.UpdateAsync(accountRequestId, Constants.STATUS_APPROVED);

            var accountRequest = await _accountRequestService.GetByIdAsync(accountRequestId);

            if (accountRequest.AccountTypeVM.Name == Constants.ACCOUNTTYPE_SAVINGS)
            {
                await _accountsService.CreateSavingsAccountAcync(accountRequest.AccountTypeVM, accountRequest.UserId);
            }
            else
            {
                await _accountsService.CreateTransactionalAccountAsync(accountRequest.AccountTypeVM, accountRequest.UserId);
            }
        }

        public async Task<List<AccountRequestVM>> GetPendingAccountRequestsAsync()
        {
            var pendingAccountRequests = await _accountRequestService.GetAllByStatusAsync(Constants.STATUS_PENDING);
            return pendingAccountRequests;
        }

        public async Task<List<AccountRequestVM>> GetAccountRequestsByStatusAsync(string status)
        {
            var accountRequests = await _accountRequestService.GetAllByStatusAsync(status);
            return accountRequests;
        }

        public async Task<List<AccountRequestVM>> GetAllAccountRequestsAsync()
        {
            var accountRequests = await _accountRequestService.GetAllAsync();
            return accountRequests;
        }

        public async Task RejectAccountRequestAsync(int accountRequestId)
        {
            await _accountRequestService.UpdateAsync(accountRequestId, Constants.STATUS_REJECTED);
        }
    }
}
