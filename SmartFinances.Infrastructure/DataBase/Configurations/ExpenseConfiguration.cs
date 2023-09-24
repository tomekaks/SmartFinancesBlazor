using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.Name)
                   .IsRequired();

            builder.Property(e => e.Amount)
                   .IsRequired();

            builder.HasOne(e => e.ExpenseType)
                   .WithMany(et => et.Expenses)
                   .HasForeignKey(e => e.ExpenseTypeId)
                   .IsRequired();

            builder.HasOne(e => e.Account)
                   .WithMany(a => a.Expenses)
                   .HasForeignKey(e => e.AccountId)
                   .IsRequired();
        }
    }
}
