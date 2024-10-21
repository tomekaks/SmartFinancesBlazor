using Microsoft.EntityFrameworkCore;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using SmartFinances.Infrastructure.DataBase;

namespace SmartFinances.Infrastructure.Repositories
{
    public class YearlySummaryRepository : GenericRepository<YearlySummary>, IYearlySummaryRepository
    {
        public YearlySummaryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<YearlySummary> GetYearlySummaryWithChildrenAsync(int accountId, int year)
        {
            var yearlySummary = await _db.Include(y => y.MonthlySummaries)
                                        .ThenInclude(m => m.Expenses)
                                        .ThenInclude(e => e.ExpenseType)
                                        .FirstOrDefaultAsync(q => q.TransactionalAccountId == accountId && q.Year == year);

            return yearlySummary;
        }
    }
}
