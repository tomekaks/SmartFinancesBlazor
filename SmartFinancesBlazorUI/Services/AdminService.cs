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
        private readonly IAccountRequestService _accountRequestService;
        private readonly IAccountsService _accountsService;

        public AdminService(IClient client, ILocalStorageService localStorage,
            IAccountRequestService accountRequestService, IAccountsService accountsService)
            : base(client, localStorage)
        {
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
                return;
            }

            await _accountsService.CreateTransactionalAccountAsync(accountRequest.AccountTypeVM, accountRequest.UserId);
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
