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

    }
}
