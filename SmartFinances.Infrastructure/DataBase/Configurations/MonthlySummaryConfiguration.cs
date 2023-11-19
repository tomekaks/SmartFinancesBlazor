using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class MonthlySummaryConfiguration : IEntityTypeConfiguration<MonthlySummary>
    {
        public void Configure(EntityTypeBuilder<MonthlySummary> builder)
        {
            builder.Property(m => m.Month).IsRequired();

            builder.HasOne(m => m.YearlySummary)
                   .WithMany(y => y.MonthlySummaries)
                   .HasForeignKey(m => m.YearlySummaryId)
                   .IsRequired();

            builder.HasMany(m => m.Expenses)
                   .WithOne(e => e.MonthlySummary)
                   .HasForeignKey(e => e.MonthlySummaryId);
        }
    }
}
