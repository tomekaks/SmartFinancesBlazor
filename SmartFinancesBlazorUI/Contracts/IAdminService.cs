using SmartFinancesBlazorUI.Models.Admin;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAdminService
    {
        Task<List<AccountRequestVM>> GetPendingAccountRequestsAsync();
        Task ApproveAccountRequestAsync(int accountRequestId);
        Task RejectAccountRequestAsync(int accountRequestId);
    }
}
