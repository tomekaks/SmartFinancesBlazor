using SmartFinancesBlazorUI.Models.Admin;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountRequestService
    {
        Task CreateAsync(string accountType);
        Task UpdateAsync(int accountTypeId, string status);
        Task<AccountRequestVM> GetByIdAsync(int accountTypeId);
        Task<List<AccountRequestVM>> GetAllByStatusAsync(string status);
        Task<List<AccountRequestVM>> GetByUserAndStatusAsync(string status);
    }
}
