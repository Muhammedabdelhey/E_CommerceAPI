﻿using E_Commerce.Domain.Enums;

namespace E_Commerce.Presentation.Extensions
{
    public static class AddAuthorizationPoliciesExtension
    {
        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                foreach (Permissions PermissionName in Enum.GetValues(typeof(Permissions)))
                {
                    options.AddPolicy($"{PermissionName}", policy =>
                        policy.RequireClaim(typeof(Permissions).Name, PermissionName.ToString()));
                }
            });
        }
    }
}
