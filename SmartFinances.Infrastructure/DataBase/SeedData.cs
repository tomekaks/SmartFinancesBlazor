using Microsoft.AspNetCore.Identity;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Infrastructure.DataBase
{
    public static class SeedData
    {
        private static readonly RoleManager<IdentityRole> _roleManager;
        private static readonly UserManager<ApplicationUser> _userManager;

        public static void Seed(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole()
                {
                    Name = "Administrator"
                };
                roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole()
                {
                    Name = "User"
                };
                roleManager.CreateAsync(role);
            }
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@email.com"
            };

            var result = userManager.CreateAsync(user, "Password!23").Result;
            
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Administrator").Wait();
            }
        }
    }
}
