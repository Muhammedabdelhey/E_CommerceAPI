using E_Commerce.Application.Common.Services;
using E_Commerce.Application.Models;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(EntityExistenceValidator<>));
            services.AddTransient(typeof(UserExistenceValidator));
            services.AddTransient(typeof(RoleExistenceValidator));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IFileService), typeof(FileService));
            services.Configure<JwtOptions>(configuration.GetSection("JWT"));
            services.AddTransient(typeof(JwtService));
            services.AddHttpContextAccessor();
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper registration
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
