using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Json;
using System.Reflection;

namespace SmartFinancesBlazorUI.Services
{
    public class TransfersService : BaseHttpService, ITransfersService
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IContactsService _contactsService;
        public TransfersService(IClient client, IMapper mapper, ILocalStorageService localStorage, 
            IAccountService accountService, IContactsService contactsService)
            : base(client, localStorage)
        {
            _mapper = mapper;
            _accountService = accountService;
            _contactsService = contactsService;
        }

        public async Task<bool> CreateTransferAsync(NewTransferVM transferVM, bool addToContacts)
        {
            if (addToContacts == true)
            {
                var newContact = new NewContactVM()
                {
                    Name = transferVM.ReceiverName,
                    AccountNumber = transferVM.ReceiverAccountNumber
                };
                await _contactsService.CreateContactAsync(newContact);
            }

            transferVM.SendTime = DateTime.UtcNow;
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);
            transferDto.SenderAccountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

        public async Task<TransactionalAccountVM> GetCurrentAccountAsync()
        {
            var currentAccountNumber = await GetCurrentAccountNumberAsync();

            var currentAccount = await _accountService.GetTransactionalAccountByNumberAsync(currentAccountNumber);

            return currentAccount;
        }

        public async Task DepositOnSavingsAccountAsync(SavingsAccountTransferDto transferDto)
        {
            await AddBearerToken();
            await _client.TransfersDepositToSavingsAccountAsync(transferDto);
        }

        public async Task<TransfersOverviewVM> GenerateTransfersOverviewVM()
        {
            string currentAccount = await GetCurrentAccountNumberAsync();

            var transfersVM = await GetTransfersAsync(currentAccount);
            var orderedTransfers = transfersVM.OrderByDescending(q => q.SendTime).ToList();

            foreach (var transfer in orderedTransfers)
            {
                transfer.CurrentAccountNumber = currentAccount;
            }

            return new TransfersOverviewVM()
            {
                Transfers = orderedTransfers,
                AccountNumber = currentAccount
            };
        }

        public async Task WithdrawFromSavingsAccountAsync(SavingsAccountTransferDto transferDto)
        {
            await AddBearerToken();
            await _client.TransfersWithdrawFromSavingsAccountAsync(transferDto);
        }

        private async Task<List<TransferVM>> GetTransfersAsync(string currentAccount)
        {
            await AddBearerToken();
            var transfers = await _client.TransfersGetAllAsync(currentAccount);

            if (transfers == null || transfers.Count < 1)
            {
                return new List<TransferVM>();
            }

            var transferList = _mapper.Map<List<TransferVM>>(transfers);
            
            return transferList;
        }
    }
}
