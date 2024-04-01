using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;

namespace SmartFinances.Infrastructure.DataBase.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(q => q.Message)
                   .IsRequired();

            builder.Property(n => n.IsRead)
                  .IsRequired();

            builder.Property(q => q.DateCreated)
                   .IsRequired();

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(c => c.UserId)
                   .IsRequired();
        }
    }
}
