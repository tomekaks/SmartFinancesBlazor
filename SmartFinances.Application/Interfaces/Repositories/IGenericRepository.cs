using System.Linq.Expressions;

namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, string includeProperties = null);
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, string includeProperties = null);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
