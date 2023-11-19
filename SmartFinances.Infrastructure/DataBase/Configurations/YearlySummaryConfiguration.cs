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

            builder.HasOne(y => y.Account)
                   .WithMany(a => a.YearlySummaries)
                   .HasForeignKey(y => y.AccountId)
                   .IsRequired();

            builder.HasMany(y => y.MonthlySummaries)
                   .WithOne(m => m.YearlySummary)
                   .HasForeignKey(m => m.YearlySummaryId);
        }
    }
}
