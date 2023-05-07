using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class RegularExpenseConfiguration
    {
        public void Configure(EntityTypeBuilder<RegularExpense> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.Type)
                   .IsRequired()
                   .HasConversion<string>();

            builder.HasOne(r => r.Account)
                   .WithMany(a => a.RegularExpenses)
                   .HasForeignKey(r => r.AccountId);
        }
    }
}
