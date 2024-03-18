using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    internal class TransactionalAccountConfiguration : IEntityTypeConfiguration<TransactionalAccount>
    {
        public void Configure(EntityTypeBuilder<TransactionalAccount> builder)
        {
            builder.Property(q => q.Number)
                .IsRequired();

            builder.Property(q => q.Balance)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(q => q.Name)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithMany(u => u.TransactionalAccounts)
                .HasForeignKey(t => t.UserId);

            builder.Property(q => q.Type)
                .IsRequired();
        }
    }
}
