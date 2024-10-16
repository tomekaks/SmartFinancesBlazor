﻿using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;

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

        public async Task<bool> CreateTransferAsync(NewTransferVM transferVM)
        {
            var receiverAccount = await _accountService.CheckIfTransactionalAccountExistsAsync(transferVM.ReceiverAccountNumber);
            if (receiverAccount == null)
            {
                return false;
            }

            transferVM.SendTime = DateTime.UtcNow;
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);
            transferDto.SenderAccountNumber = await GetCurrentAccountNumberAsync();

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
            await _client.TransfersDepositToSavingsAccountAsync(transferDto);
        }

        public async Task<TransfersOverviewVM> GenerateTransfersOverviewVM()
        {
            var currentAccount = await GetCurrentAccountAsync();

            var transfersVM = await GetTransfersAsync(currentAccount.Number);
            var orderedTransfers = transfersVM.OrderByDescending(q => q.SendTime).ToList();

            foreach (var transfer in orderedTransfers)
            {
                transfer.CurrentAccountNumber = currentAccount.Number;
            }

            return new TransfersOverviewVM()
            {
                Transfers = orderedTransfers,
                CurrentAccount = currentAccount,
                AccountNumber = currentAccount.Number
            };
        }

        public async Task WithdrawFromSavingsAccountAsync(SavingsAccountTransferDto transferDto)
        {
            await _client.TransfersWithdrawFromSavingsAccountAsync(transferDto);
        }

        public async Task<bool> AddToContactsAsync(NewTransferVM transferVM)
        {
            var newContact = new NewContactVM()
            {
                Name = transferVM.ReceiverName,
                AccountNumber = transferVM.ReceiverAccountNumber
            };

            return await _contactsService.CreateContactAsync(newContact);
        }

        private async Task<List<TransferVM>> GetTransfersAsync(string currentAccount)
        {
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
