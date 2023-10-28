using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(q => q.Number)
                   .IsRequired(true);

            builder.Property(q => q.Balance)
                   .IsRequired();

            builder.Property(q => q.Type)
                   .IsRequired();

            builder.HasOne(a => a.User)
                   .WithMany(u => u.Accounts)
                   .HasForeignKey(a => a.UserId);

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
