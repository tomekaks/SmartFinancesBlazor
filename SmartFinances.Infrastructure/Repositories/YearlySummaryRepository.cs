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
    }
}
