using SmartFinancesBlazorUI.Models.Authentication;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> LoginAsync(LoginVM loginVM);
        Task<RegistrationResponse> RegisterAsync(RegisterVM registerVM);
        Task Logout();
    }
}
