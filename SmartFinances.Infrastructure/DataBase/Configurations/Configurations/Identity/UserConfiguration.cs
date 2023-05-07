using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.DataBase.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser()
                {
                    Id = "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                    Email = "admin@email.com",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "Password!23"),
                    EmailConfirmed = true
                },
                new ApplicationUser()
                {
                    Id = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                    Email = "sarahconor@skynet.com",
                    NormalizedEmail = "SARAHCONNOR@SKYNET.COM",
                    FirstName = "Sarah",
                    LastName = "Connor",
                    UserName = "ILikeRobots",
                    NormalizedUserName = "ILIKEROBOTS",
                    PasswordHash = hasher.HashPassword(null, "Password!23"),
                    EmailConfirmed = true
                },
                new ApplicationUser()
                {
                    Id = "8f095269-a72b-4427-bcaf-d860249770c9",
                    Email = "tylerdurden@fightclub.com",
                    NormalizedEmail = "TYLERDURDEN@FIGHTCLUB.COM",
                    FirstName = "Tyler",
                    LastName = "Durden",
                    UserName = "FirstRule",
                    NormalizedUserName = "FIRSTRULE",
                    PasswordHash = hasher.HashPassword(null, "Password!23"),
                    EmailConfirmed = true
                });
        }
    }
}
