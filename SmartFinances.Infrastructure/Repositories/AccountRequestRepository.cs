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

        public async Task<List<AccountRequest>> GetAllByStatusAsync(string status)
        {
            var accountRequests = await _db
                .Include(q => q.User)
                .Include(q => q.AccountType)
                .Where(q => q.Status == status)
                .ToListAsync();

            return accountRequests;
        }
    }
}
