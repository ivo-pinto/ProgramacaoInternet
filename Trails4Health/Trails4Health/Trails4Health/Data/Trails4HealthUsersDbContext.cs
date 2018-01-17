using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using Microsoft.AspNetCore.Identity;

namespace Trails4Health.Data
{
    public class Trails4HealthUsersDbContext : IdentityDbContext<ApplicationUser>
    {
        public Trails4HealthUsersDbContext(DbContextOptions<Trails4HealthUsersDbContext> options)
            : base(options)
        {
        }

/*  REVER CÓDIGO-----------------------------------------------------------------------------------------------------------------------
        public static async Task EnsurePopulatedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // ...
            if (!await roleManager.RoleExistsAsync("Administrator")) await roleManager.CreateAsync(new IdentityRole("Administrator"));
            if (!await roleManager.RoleExistsAsync("Customer")) await roleManager.CreateAsync(new IdentityRole("Customer"));
            // ...
            ApplicationUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = adminUser };
                await userManager.CreateAsync(user, adminPassword);
            }
            if (!await userManager.IsInRoleAsync(user, "Administrator")) await userManager.AddToRoleAsync(user, "Administrator");
        }
        */

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}