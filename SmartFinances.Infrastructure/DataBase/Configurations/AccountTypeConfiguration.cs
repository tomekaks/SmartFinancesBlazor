using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.Property(et => et.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(et => et.Name)
                   .IsUnique();

            builder.HasData(
                new AccountType { Id = 1, Name = "Main"},
                new AccountType { Id = 2, Name = "Secondary"},
                new AccountType { Id = 3, Name = "Business"}
                );

        }
    }
}
