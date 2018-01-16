using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class UsersSeedData
    {
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Secret123$";
            ApplicationUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = adminUser };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
