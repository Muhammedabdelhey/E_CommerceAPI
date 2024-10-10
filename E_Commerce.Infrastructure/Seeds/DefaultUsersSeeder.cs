using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure.Seeds
{
    public static class DefaultUsersSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            User superAdmin = new()
            {
                UserName = "Superadmin",
                Email = "Superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };
            if (await userManager.FindByEmailAsync(superAdmin.Email) is null)
            {
                var result =await userManager.CreateAsync(superAdmin, "Superadmin@Superadmin123");
                await userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin.ToString());
            }

            User admin = new()
            {
                UserName = "Admin",
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };
            if (await userManager.FindByEmailAsync(admin.Email) is null)
            {
                await userManager.CreateAsync(admin, "Admin@Admin123");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());

            }

            User vendor = new()
            {
                UserName = "Vendor",
                Email = "Vendor@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };
            if (await userManager.FindByEmailAsync(vendor.Email) is null)
            {
                await userManager.CreateAsync(vendor, "Vendor@Vendor123");
                await userManager.AddToRoleAsync(vendor, Roles.Vendor.ToString());
            }

            User user = new()
            {
                UserName = "User",
                Email = "User@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };
            if (await userManager.FindByEmailAsync(user.Email) is null)
            {
                await userManager.CreateAsync(user, "User@User123");
                await userManager.AddToRoleAsync(user, Roles.User.ToString());
            }
        }
    }
}
