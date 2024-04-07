using SmartFinancesBlazorUI.Models.AccountTypes;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountTypesService
    {
        Task<List<AccountTypeVM>> GetAllAsync();
    }
}
