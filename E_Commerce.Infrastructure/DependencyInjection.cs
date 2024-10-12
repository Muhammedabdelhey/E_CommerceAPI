using E_Commerce.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("default");
            var connectionString = configuration.GetConnectionString("company");
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSingleton(TimeProvider.System);
            services.AddScoped(typeof(IFileAdapter), typeof(LocalFileAdapter));
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString)
                       .AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
            //DefaultRolesSeeder.SeedRolesAsync(services.BuildServiceProvider()).Wait();
            //DefaultUsersSeeder.SeedUsersAsync(services.BuildServiceProvider()).Wait();
            return services;
        }
    }
}
