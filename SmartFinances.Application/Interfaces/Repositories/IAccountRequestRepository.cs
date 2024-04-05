using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface IAccountRequestRepository : IGenericRepository<AccountRequest>
    {
        Task<List<AccountRequest>> GetUsersAccountRequestsByStatus(string userId, string status);
    }
}
