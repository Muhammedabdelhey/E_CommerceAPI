using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure.Seeds
{
    public  class DefaultRolesSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Check and create SuperAdmin role
            if (!await roleManager.RoleExistsAsync(Roles.SuperAdmin.ToString()))
            {
                var superAdmin = new IdentityRole
                {
                    Name = Roles.SuperAdmin.ToString(),
                    NormalizedName = Roles.SuperAdmin.ToString().ToUpper()
                };
                await roleManager.CreateAsync(superAdmin);
            }

            // Check and create Admin role
            if (!await roleManager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                var admin = new IdentityRole
                {
                    Name = Roles.Admin.ToString(),
                    NormalizedName = Roles.Admin.ToString().ToUpper()
                };
                await roleManager.CreateAsync(admin);
            }

            // Check and create Vendor role
            if (!await roleManager.RoleExistsAsync(Roles.Vendor.ToString()))
            {
                var vendor = new IdentityRole
                {
                    Name = Roles.Vendor.ToString(),
                    NormalizedName = Roles.Vendor.ToString().ToUpper()
                };
                await roleManager.CreateAsync(vendor);
            }

            // Check and create User role
            if (!await roleManager.RoleExistsAsync(Roles.User.ToString()))
            {
                var user = new IdentityRole
                {
                    Name = Roles.User.ToString(),
                    NormalizedName = Roles.User.ToString().ToUpper()
                };
                await roleManager.CreateAsync(user);
            }
        }
    }
}
