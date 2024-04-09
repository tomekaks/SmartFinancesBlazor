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
                new AccountType { Id = 2, Name = "Secondary"},
                new AccountType { Id = 3, Name = "Business"},
                new AccountType { Id = 4, Name = "Savings"}
                );

        }
    }
}
