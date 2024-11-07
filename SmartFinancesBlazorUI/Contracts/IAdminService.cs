using SmartFinancesBlazorUI.Models.Admin;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAdminService
    {
        Task<List<AccountRequestVM>> GetPendingAccountRequestsAsync();
        Task<List<AccountRequestVM>> GetAccountRequestsByStatusAsync(string status);
        Task<List<AccountRequestVM>> GetAllAccountRequestsAsync();
        Task ApproveAccountRequestAsync(int accountRequestId);
        Task RejectAccountRequestAsync(int accountRequestId);
    }
}
