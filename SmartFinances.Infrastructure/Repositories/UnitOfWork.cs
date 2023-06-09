﻿using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Accounts = new AccountRepository(context);
            Transfers = new TransferRepository(context);
            Expenses = new ExpenseRepositiory(context);
            RegularExpenses = new RegularExpenseRepository(context);
            Contacts = new ContactRepository(context);
            Users = new UserRepository(context);
        }

        public IAccountRepository Accounts { get; private set; }
        public ITransferRepository Transfers { get; private set; }
        public IExpenseRepository Expenses { get; private set; }
        public IRegularExpenseRepository RegularExpenses { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IUserRepository Users { get; private set; }


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
