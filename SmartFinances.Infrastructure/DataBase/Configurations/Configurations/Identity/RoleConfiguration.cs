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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole()
                {
                    Id = "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole()
                {
                    Id = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                    Name = "TestUser",
                    NormalizedName = "TESTUSER"
                },
                new IdentityRole()
                {
                    Id = "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                    Name = "User",
                    NormalizedName = "USER"
                });
        }
    }
}
