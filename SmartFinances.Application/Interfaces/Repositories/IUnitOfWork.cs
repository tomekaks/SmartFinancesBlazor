using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository Accounts { get; }
        public ITransferRepository Transfers { get; }
        public IExpenseRepository Expenses { get; }
        public IExpenseTypeRepository ExpenseTypes { get; }
        public IRegularExpenseRepository RegularExpenses { get; }
        public IContactRepository Contacts { get; }
        public IUserRepository Users { get; }
        Task SaveAsync();
    }
}
