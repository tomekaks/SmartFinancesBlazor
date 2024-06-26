﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<RegularExpense> RegularExpenses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<MonthlySummary> MonthlySummaries { get; set; }
        public DbSet<YearlySummary> YearlySummaries { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
        public DbSet<TransactionalAccount> TransactionalAccounts { get; set; }
        public DbSet<AccountRequest> AccountRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
