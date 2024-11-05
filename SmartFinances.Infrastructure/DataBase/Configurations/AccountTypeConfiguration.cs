using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.Property(et => et.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(et => et.Name)
                   .IsUnique();

            builder.HasMany(a => a.TransactionalAccounts)
                .WithOne(t => t.AccountType)
                .HasForeignKey(t => t.AccountTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.SavingsAccounts)
                .WithOne(s => s.AccountType)
                .HasForeignKey(s => s.AccountTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.AccountRequests)
                .WithOne(r => r.AccountType)
                .HasForeignKey(r => r.AccountTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new AccountType { Id = 1, Name = "Main"},
                new AccountType 
                {   Id = 2, 
                    Name = "Secondary", 
                    Description = "Manage your everyday expenses with ease. " +
                    "A Secondary Account offers all the transactional features of your Main Account, " +
                    "allowing you to separate personal spending, track budgets, and maintain better financial organization." 
                },
                new AccountType 
                {   Id = 3, 
                    Name = "Business",
                    Description = "Designed for entrepreneurs and small businesses, " +
                    "the Business Account provides specialized tools for managing company finances. " +
                    "Enjoy streamlined transactions, expense tracking, and dedicated support to help your business thrive."
                },
                new AccountType 
                { 
                    Id = 4, 
                    Name = "Savings",
                    Description = "Grow your wealth securely with our Savings Account. " +
                    "Benefit from competitive interest rates, automatic savings plans, " +
                    "and robust security features to ensure your funds are always protected and working for you."
                }
                );

        }
    }
}
