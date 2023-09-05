using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.DataBase.Configurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                    UserId = "5330c916-053d-41e6-8a44-b9fe25cf27bf"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                    UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                    UserId = "8f095269-a72b-4427-bcaf-d860249770c9"
                });
        }
    }
}
