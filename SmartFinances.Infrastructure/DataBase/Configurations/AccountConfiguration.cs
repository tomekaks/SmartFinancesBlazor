using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(q => q.Number)
                   .IsRequired();

            builder.Property(q => q.Balance)
                   .HasPrecision(18,2);

            builder.Property(q => q.Budget)
                   .HasPrecision(18, 2);

            builder.HasOne(a => a.User)
                   .WithMany(u => u.Accounts)
                   .HasForeignKey(a => a.UserId)
                   .IsRequired();

            builder.HasMany(a => a.YearlySummaries)
                   .WithOne(y => y.Account)
                   .HasForeignKey(y => y.AccountId);

            builder.HasData(
                new Account()
                {
                    Id = - 1,
                    Number = "11AAAA111111",
                    Type = 1,
                    UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                    Balance = 2000,
                    Budget = 0
                },
                new Account()
                {
                    Id = - 2,
                    Number = "22BBBB222222",
                    Type = 1,
                    UserId = "8f095269-a72b-4427-bcaf-d860249770c9",
                    Balance = 2000,
                    Budget = 0
                },
                new Account()
                {
                    Id = - 3,
                    Number = "33CCCC333333",
                    Type = 2,
                    UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                    Balance = 2000,
                    Budget = 0
                },
                new Account()
                {
                    Id = - 4,
                    Number = "44DDDD444444",
                    Type = 3,
                    UserId = "8f095269-a72b-4427-bcaf-d860249770c9",
                    Balance = 2000,
                    Budget = 0
                });

        }
    }
}
