using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.Property(et => et.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(et => et.Name)
                   .IsUnique();

            builder.HasMany(et => et.Expenses)
                   .WithOne(e => e.ExpenseType)
                   .HasForeignKey(e => e.ExpenseTypeId);

            builder.HasMany(et => et.RegularExpenses)
                   .WithOne(re => re.ExpenseType)
                   .HasForeignKey(re => re.ExpenseTypeId);

            builder.HasData(
                new ExpenseType { Id = 1, Name = "Housing"},
                new ExpenseType { Id = 2, Name = "Utilities" },
                new ExpenseType { Id = 3, Name = "Food"},
                new ExpenseType { Id = 4, Name = "Clothes"},
                new ExpenseType { Id = 5, Name = "Health"},
                new ExpenseType { Id = 6, Name = "Entertainment" },
                new ExpenseType { Id = 7, Name = "Transportation" },
                new ExpenseType { Id = 8, Name = "Personal" },
                new ExpenseType { Id = 9, Name = "Household" }
                );
        }
    }
}
