﻿using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
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

        public async Task<TransfersOverviewVM> GenerateTransfersOverviewVM(int pageNumber = 1)
        {
            var currentAccount = await GetCurrentAccountAsync();

            var transfersVM = await GetPaginatedTransfersAsync(currentAccount.Number, pageNumber);

            var orderedTransfers = transfersVM.Items.OrderByDescending(q => q.SendTime).ToList();

            foreach (var transfer in orderedTransfers)
            {
                transfer.CurrentAccountNumber = currentAccount.Number;
            }

            var groupedTransfers = orderedTransfers.GroupBy(q => q.SendTime).ToList();

            return new TransfersOverviewVM()
            {
                Transfers = orderedTransfers,
                CurrentAccount = currentAccount,
                AccountNumber = currentAccount.Number,
                GroupedTransfers = groupedTransfers
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

        private async Task<PaginatedList<TransferVM>> GetPaginatedTransfersAsync(string currentAccount, int pageNumber = 1, int pageSize = 10)
        {
            var transfersDto = await _client.TransfersGetWithPaginationAsync(currentAccount, pageNumber, pageSize);

            if (transfersDto == null || transfersDto.Items.Count < 1)
            {
                return new PaginatedList<TransferVM>(new List<TransferVM>(), 1, 10, 1, 0);
            }

            var transfersVM = _mapper.Map<List<TransferVM>>(transfersDto.Items);

            var paginaterTransfersVM = new PaginatedList<TransferVM>(
                transfersVM, transfersDto.PageNumber, transfersDto.PageSize, transfersDto.TotalPages, transfersDto.TotalCount);


            return paginaterTransfersVM;
        }

    }
}
