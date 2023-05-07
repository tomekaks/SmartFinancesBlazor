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
    public class ExpenseRepositiory : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly ApplicationDbContext _context;
        public ExpenseRepositiory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
