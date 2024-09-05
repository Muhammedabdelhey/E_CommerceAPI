﻿using E_Commerce.Application.Common.Interfacses;
using E_Commerce.Presentation.Services;

namespace E_Commerce.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<IUser, CurrentUser>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}