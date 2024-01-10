using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface IYearlySummaryRepository : IGenericRepository<YearlySummary>
    {
        Task<YearlySummary> GetYearlySummaryWithChildren(int accountId, int year);
    }
}
