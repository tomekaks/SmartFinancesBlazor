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
                .HasPrecision(18, 2);

            builder.Property(q => q.Budget)
                .HasPrecision(18, 2);

            builder.Property(q => q.Name)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithMany(u => u.TransactionalAccounts)
                .HasForeignKey(t => t.UserId)
                .IsRequired();

            builder.Property(q => q.CreationDateTime)
                .IsRequired();

            builder.HasMany(t => t.RegularExpenses)
                .WithOne(r => r.TransactionalAccount)
                .HasForeignKey(r => r.TransactionalAccountId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasMany(t => t.YearlySummaries)
                .WithOne(y => y.TransactionalAccount)
                .HasForeignKey(y => y.TransactionalAccountId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new TransactionalAccount()
                {
                    Id = -1,
                    Number = "11AAAA111111",
                    Type = 1,
                    Name = "ILikeRobots",
                    UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                    Balance = 2000,
                    CreationDateTime = DateTime.UtcNow
                },
                new TransactionalAccount()
                {
                    Id = -2,
                    Number = "22BBBB222222",
                    Type = 1,
                    Name = "FirstRule",
                    UserId = "8f095269-a72b-4427-bcaf-d860249770c9",
                    Balance = 2000,
                    CreationDateTime = DateTime.UtcNow
                });
        }
    }
}
