using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

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
                   .IsRequired();

            builder.HasOne(e => e.Account)
                   .WithMany(a => a.Expenses)
                   .HasForeignKey(e => e.AccountId);
        }
    }
}
