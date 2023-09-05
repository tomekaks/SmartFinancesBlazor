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
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.Property(q => q.Amount)
                   .IsRequired();

            builder.Property(q => q.SendTime)
                   .IsRequired();

            builder.Property(q => q.Title)
                   .IsRequired();

            builder.Property(q => q.ReceiverAccountNumber)
                   .IsRequired();

            builder.Property(q => q.ReceiverName)
                   .IsRequired();

            builder.HasOne(t => t.Account)
                   .WithMany(a => a.Transfers)
                   .HasForeignKey(t => t.AccountId);
        }
    }
}
