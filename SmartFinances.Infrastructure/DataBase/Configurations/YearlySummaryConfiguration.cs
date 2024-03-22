using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class YearlySummaryConfiguration : IEntityTypeConfiguration<YearlySummary>
    {
        public void Configure(EntityTypeBuilder<YearlySummary> builder)
        {
            builder.Property(y => y.Year).IsRequired();

            builder.Property(m => m.Budget)
                   .HasPrecision(18, 2);

            builder.Property(m => m.AmountSpent)
                   .HasPrecision(18, 2);

            builder.Property(m => m.AmountSaved)
                   .HasPrecision(18, 2);

            builder.HasOne(y => y.Account)
                   .WithMany(a => a.YearlySummaries)
                   .HasForeignKey(y => y.AccountId)
                   .IsRequired();

            builder.HasOne(y => y.TransactionalAccount)
                   .WithMany(t => t.YearlySummaries)
                   .HasForeignKey(y => y.TransactionalAccountId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(y => y.MonthlySummaries)
                   .WithOne(m => m.YearlySummary)
                   .HasForeignKey(m => m.YearlySummaryId);
        }
    }
}
