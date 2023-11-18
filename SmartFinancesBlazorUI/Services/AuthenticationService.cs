using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Authentication;
using SmartFinancesBlazorUI.Providers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationService(IClient client, ILocalStorageService localStorageService, 
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> LoginAsync(LoginVM loginVM)
        {
            try
            {
                LoginRequest loginRequest = new()
                {
                    UserName = loginVM.UserName,
                    Password= loginVM.Password
                };

                var authResponse = await _client.LoginAsync(loginRequest);

                if (authResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authResponse.Token);

                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(Constants.CURRENTACCOUNT);
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(RegisterVM registerVM)
        {
            RegisterRequest registerRequest = new()
            {
                UserName= registerVM.UserName,
                Email= registerVM.Email,
                Password= registerVM.Password
            };

            var response = await _client.RegisterAsync(registerRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
