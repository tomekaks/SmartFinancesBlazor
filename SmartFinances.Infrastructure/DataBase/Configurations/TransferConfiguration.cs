using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.Property(q => q.Amount)
                   .HasPrecision(18,2);

            builder.Property(q => q.SendTime)
                   .IsRequired();

            builder.Property(q => q.Title)
                   .IsRequired();

            builder.Property(q => q.ReceiverAccountNumber)
                   .IsRequired();

            builder.Property(q => q.ReceiverName)
                   .IsRequired();

            builder.Property(q => q.SenderAccountNumber)
                   .IsRequired();

            builder.Property(q => q.SenderName)
                   .IsRequired();

        }
    }
}
