using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface IYearlySummaryRepository : IGenericRepository<YearlySummary>
    {
        Task<YearlySummary> GetYearlySummaryWithChildrenAsync(int accountId, int year);
    }
}
