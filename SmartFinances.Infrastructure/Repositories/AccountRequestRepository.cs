using Microsoft.EntityFrameworkCore;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using SmartFinances.Infrastructure.DataBase;

namespace SmartFinances.Infrastructure.Repositories
{
    public class AccountRequestRepository : GenericRepository<AccountRequest>, IAccountRequestRepository
    {
        public AccountRequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<AccountRequest>> GetUsersAccountRequestsByStatus(string userId, string status)
        {
            var accountRequests = await _db.Where(q => q.UserId == userId && q.Status == status).ToListAsync();
            return accountRequests;
        }
    }
}
