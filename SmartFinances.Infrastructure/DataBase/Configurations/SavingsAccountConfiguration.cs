using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    internal class SavingsAccountConfiguration : IEntityTypeConfiguration<SavingsAccount>
    {
        public void Configure(EntityTypeBuilder<SavingsAccount> builder)
        {
            builder.Property(q => q.Number)
                .IsRequired();

            builder.Property(q => q.Balance)
                .HasPrecision(18, 2);

            builder.Property(q => q.Goal)
                .HasPrecision(18, 2);

            builder.Property(q => q.Name)
                .IsRequired();

            builder.HasOne(s => s.User)
                .WithOne(u => u.SavingsAccount)
                .HasForeignKey<SavingsAccount>(s => s.UserId)
                .IsRequired();

            builder.Property(q => q.CreationDateTime)
                .IsRequired();

            builder.HasOne(s => s.AccountType)
                .WithMany(a => a.SavingsAccounts)
                .HasForeignKey(s => s.AccountTypeId)
                .IsRequired();
        }
    }
}
