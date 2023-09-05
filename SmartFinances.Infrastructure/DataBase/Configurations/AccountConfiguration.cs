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
        }
    }
}
