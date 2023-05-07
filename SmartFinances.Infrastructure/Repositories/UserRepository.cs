using Microsoft.EntityFrameworkCore;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using SmartFinances.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ApplicationUser> _users;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            return await _users.FindAsync(id);
        }

        public void Update(ApplicationUser user)
        {
            _users.Update(user);
        }
    }
}
