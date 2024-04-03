using SmartFinancesBlazorUI.Models.Admin;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAdminService
    {
        Task<List<AccountRequestVM>> GetPendingAccountRequestsAsync();
    }
}
