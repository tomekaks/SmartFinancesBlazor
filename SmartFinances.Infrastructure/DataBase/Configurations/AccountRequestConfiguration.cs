using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    internal class AccountRequestConfiguration : IEntityTypeConfiguration<AccountRequest>
    {
        public void Configure(EntityTypeBuilder<AccountRequest> builder)
        {
            builder.Property(q => q.Type)
                   .IsRequired();

            builder.Property(q => q.Status)
                   .IsRequired();

            builder.Property(q => q.DateRequested)
                   .IsRequired();

            builder.Property(q => q.DateApproved)
                   .IsRequired(false);

            builder.Property(q => q.DateRejected)
                   .IsRequired(false);

            builder.HasOne(c => c.User)
                   .WithMany(u => u.AccountRequests)
                   .HasForeignKey(c => c.UserId)
                   .IsRequired();

            builder.HasOne(r => r.AccountType)
                   .WithMany(t => t.AccountRequests)
                   .HasForeignKey(r => r.AccountTypeId)
                   .IsRequired();
        }
    }
}
