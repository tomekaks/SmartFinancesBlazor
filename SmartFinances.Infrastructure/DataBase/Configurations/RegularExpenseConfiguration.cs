using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class RegularExpenseConfiguration : IEntityTypeConfiguration<RegularExpense>
    {
        public void Configure(EntityTypeBuilder<RegularExpense> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .HasPrecision(18, 2);

            builder.HasOne(re => re.ExpenseType)
                   .WithMany(et => et.RegularExpenses)
                   .HasForeignKey(re => re.ExpenseTypeId)
                   .IsRequired();

            builder.HasOne(r => r.TransactionalAccount)
                   .WithMany(t => t.RegularExpenses)
                   .HasForeignKey(r => r.TransactionalAccountId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
