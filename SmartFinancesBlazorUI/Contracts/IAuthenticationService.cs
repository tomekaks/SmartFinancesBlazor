using SmartFinancesBlazorUI.Models.Authentication;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(LoginVM loginVM);
        Task<bool> RegisterAsync(RegisterVM registerVM);
        Task Logout();
    }
}
