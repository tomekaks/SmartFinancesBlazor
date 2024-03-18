using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using SmartFinances.Infrastructure.DataBase;

namespace SmartFinances.Infrastructure.Repositories
{
    public class TransactionalAccountRepository : GenericRepository<TransactionalAccount>, ITransactionalAccountRepository
    {
        public TransactionalAccountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
