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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.Type)
                   .IsRequired()
                   .HasConversion<string>();

            builder.HasOne(e => e.Account)
                   .WithMany(a => a.Expenses)
                   .HasForeignKey(e => e.AccountId);
        }
    }
}
