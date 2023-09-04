using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class UsersService : BaseHttpService, IUsersService
    {
        public UsersService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }
    }
}
