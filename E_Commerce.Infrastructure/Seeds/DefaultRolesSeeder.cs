using E_Commerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace E_Commerce.Infrastructure.Seeds
{
    public class DefaultRolesSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = await roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                await roleManager.DeleteAsync(role);
            }

            var superAdmin = new IdentityRole
            {
                Name = Roles.SuperAdmin.ToString(),
                NormalizedName = Roles.SuperAdmin.ToString().ToUpper()
            };
            await roleManager.CreateAsync(superAdmin);
            foreach (Permissions permissionName in Enum.GetValues(typeof(Permissions)))
            {
                var claim = new Claim(typeof(Permissions).Name, permissionName.ToString());
                await roleManager.AddClaimAsync(superAdmin, claim);
            }


            var user = new IdentityRole
            {
                Name = Roles.User.ToString(),
                NormalizedName = Roles.User.ToString().ToUpper()
            };
            await roleManager.CreateAsync(user);
            var Attribute_Read = new Claim(typeof(Permissions).Name, Permissions.Attribute_Read.ToString());
            await roleManager.AddClaimAsync(user, Attribute_Read);

            var Category_Read = new Claim(typeof(Permissions).Name, Permissions.Category_Read.ToString());
            await roleManager.AddClaimAsync(user, Category_Read);

            var Brand_Read = new Claim(typeof(Permissions).Name, Permissions.Brand_Read.ToString());
            await roleManager.AddClaimAsync(user, Brand_Read);

            var Product_Read = new Claim(typeof(Permissions).Name, Permissions.Product_Read.ToString());
            await roleManager.AddClaimAsync(user, Product_Read);

        }
    }
}
