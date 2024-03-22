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
                   .HasPrecision(18,2);

            builder.HasOne(e => e.ExpenseType)
                   .WithMany(et => et.Expenses)
                   .HasForeignKey(e => e.ExpenseTypeId)
                   .IsRequired();

            builder.HasOne(e => e.MonthlySummary)
                   .WithMany(m => m.Expenses)
                   .HasForeignKey(e => e.MonthlySummaryId)
                   .IsRequired();
        }
    }
}
