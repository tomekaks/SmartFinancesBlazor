using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using SmartFinances.Infrastructure.DataBase;

namespace SmartFinances.Infrastructure.Repositories
{
    public class MonthlySummaryRepository : GenericRepository<MonthlySummary>, IMonthlySummaryRepository
    {
        public MonthlySummaryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
