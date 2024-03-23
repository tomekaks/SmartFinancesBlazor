using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Infrastructure.DataBase;

namespace SmartFinances.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Transfers = new TransferRepository(context);
            Expenses = new ExpenseRepositiory(context);
            ExpenseTypes = new ExpenseTypeRepository(context);
            RegularExpenses = new RegularExpenseRepository(context);
            Contacts = new ContactRepository(context);
            Users = new UserRepository(context);
            MonthlySummaries = new MonthlySummaryRepository(context);
            YearlySummaries = new YearlySummaryRepository(context);
            TransactionalAccounts = new TransactionalAccountRepository(context);
            SavingsAccounts = new SavingsAccountRepository(context);
        }

        public ITransferRepository Transfers { get; private set; }
        public IExpenseRepository Expenses { get; private set; }
        public IExpenseTypeRepository ExpenseTypes { get; private set; }
        public IRegularExpenseRepository RegularExpenses { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IUserRepository Users { get; private set; }
        public IMonthlySummaryRepository MonthlySummaries { get; private set; }
        public IYearlySummaryRepository YearlySummaries { get; private set; }
        public ITransactionalAccountRepository TransactionalAccounts { get; private set; }
        public ISavingsAccountRepository SavingsAccounts { get; set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
