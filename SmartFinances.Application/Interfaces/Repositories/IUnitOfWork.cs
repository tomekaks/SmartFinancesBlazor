namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public ITransferRepository Transfers { get; }
        public IExpenseRepository Expenses { get; }
        public IExpenseTypeRepository ExpenseTypes { get; }
        public IRegularExpenseRepository RegularExpenses { get; }
        public IContactRepository Contacts { get; }
        public IUserRepository Users { get; }
        public IMonthlySummaryRepository MonthlySummaries { get; }
        public IYearlySummaryRepository YearlySummaries { get; }
        public ITransactionalAccountRepository TransactionalAccounts { get; }
        public ISavingsAccountRepository SavingsAccounts { get; }
        Task SaveAsync();
    }
}
