using E_Commerce.Application.Common.Interfaces;
using E_Commerce.Application.ExceptionHandlers;
using E_Commerce.Presentation.Services;

namespace E_Commerce.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<IUser, CurrentUser>();
            services.AddExceptionHandler<CustomExceptionHandler>();// should register it in program.cs
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
