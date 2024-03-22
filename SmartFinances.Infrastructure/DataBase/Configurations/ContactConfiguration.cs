using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(q => q.AccountNumber)
                   .IsRequired();

            builder.Property(q => q.Name)
                   .IsRequired();

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Contacts)
                   .HasForeignKey(c => c.UserId)
                   .IsRequired();
        }
    }
}
