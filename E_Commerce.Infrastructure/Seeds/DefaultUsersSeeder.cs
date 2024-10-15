using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure.Seeds
{
    public static class DefaultUsersSeeder
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                await userManager.DeleteAsync(user);
            }

            User superAdmin = new()
            {
                UserName = "Superadmin",
                Email = "Superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };

            await userManager.CreateAsync(superAdmin, "Superadmin@Superadmin123");
            await userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin.ToString());
            User BasicUser = new()
            {
                UserName = "User",
                Email = "User@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,

            };
            await userManager.CreateAsync(BasicUser, "User@User123");
            await userManager.AddToRoleAsync(BasicUser, Roles.User.ToString());

        }
    }
}
