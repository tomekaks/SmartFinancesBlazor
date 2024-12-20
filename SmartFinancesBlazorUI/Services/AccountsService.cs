﻿using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;
using System.Net;

namespace SmartFinancesBlazorUI.Services
{
    public class AccountsService : BaseHttpService, IAccountsService
    {
        private readonly IMapper _mapper;

        public AccountsService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task CreateSavingsAccountAcync(AccountTypeVM accountType, string requestingUserId)
        {
            var accountDto = new CreateSavingsAccountDto()
            {
                UserId = requestingUserId,
                Type = accountType.Name,
                AccountTypeId = accountType.Id
            };

            await _client.SavingsAccountsPOSTAsync(accountDto);
        }

        public async Task CreateTransactionalAccountAsync(AccountTypeVM accountType, string requestingUserId)
        {
            var accountDto = new CreateTransactionalAccountDto()
            {
                UserId= requestingUserId,
                Type = accountType.Name,
                AccountTypeId = accountType.Id,
            };

            await _client.TransactionalAccountsPOSTAsync(accountDto);
        }

        public async Task<SavingsAccountVM> GetUsersSavingsAccountAsync()
        {
            try
            {
                var savingsAccountDto = await _client.SavingsAccountsGETAsync();

                var savingsAccountVM = _mapper.Map<SavingsAccountVM>(savingsAccountDto);

                await _localStorage.SetItemAsync(Constants.SAVINGSACCOUNT, savingsAccountVM.Number);
                return savingsAccountVM;
            }
            catch (ApiException ex) when (ex.StatusCode == 404 || ex.StatusCode == 204)
            {
                return null;
            }
        }

        public async Task<TransactionalAccountVM> GetCurrentAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();
            var currentAccount = await GetTransactionalAccountByNumberAsync(accountNumber);

            return currentAccount;
        }

        public async Task<TransactionalAccountVM> GetTransactionalAccountByNumberAsync(string accountNumber)
        {
            var accountDto = await _client.TransactionalAccountsGetByNumberAsync(accountNumber);

            if (accountDto == null)
            {
                throw new Exception("Something went wrong");
            }

            return _mapper.Map<TransactionalAccountVM>(accountDto);
        }

        public async Task<List<TransactionalAccountVM>> GetUsersTransactionalAccountsAsync()
        {
            var accountsDto = await _client.TransactionalAccountsGetAllAsync();

            if (accountsDto is null || accountsDto.Count == 0)
            {
                throw new Exception("No accounts found for this user.");
            }

            var transactionalAccounts = _mapper.Map<List<TransactionalAccountVM>>(accountsDto);

            return transactionalAccounts;
        }

        public async Task UpdateTransactionalAccountAsync(int accountId, decimal balance)
        {
            var accountDto = new UpdateTransactionalAccountDto()
            {
                Id = accountId,
                Balance = balance
            };

            await _client.TransactionalAccountsPUTAsync(accountDto);
        }

        //public async Task<TransactionalAccountVM> CheckIfTransactionalAccountExistsAsync(string accountNumber)
        //{
        //    try
        //    {
        //        var account = await _client.TransactionalAccountsCheckIfExistsAsync(accountNumber);
        //        return _mapper.Map<TransactionalAccountVM>(account);
        //    }
        //    catch (ApiException ex) when (ex.StatusCode == 404)
        //    {
        //        return null;
        //    }    
        //}
        public async Task<bool> CheckIfTransactionalAccountExistsAsync(string accountNumber)
        {
            try
            {
                var account = await _client.TransactionalAccountsCheckIfExistsAsync(accountNumber);
                return true;
            }
            catch (ApiException ex) when (ex.StatusCode == 404)
            {
                return false;
            }
        }
    }
}
