﻿using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using System.Net.Http.Headers;

namespace SmartFinancesBlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly ILocalStorageService _localStorage;
        private readonly IContactsService _contactsService;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        //protected async Task AddBearerToken()
        //{
        //    if (await _localStorage.ContainKeyAsync("token"))
        //        _client.HttpClient.DefaultRequestHeaders.Authorization =
        //            new AuthenticationHeaderValue("Bearer", await
        //            _localStorage.GetItemAsync<string>("token"));
        //}

        protected async Task<string> GetCurrentAccountNumberAsync()
        {
            return await _localStorage.GetItemAsync<string>(Constants.CURRENTACCOUNT);
        }
    }
}
