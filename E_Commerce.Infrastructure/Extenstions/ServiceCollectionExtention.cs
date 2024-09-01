﻿namespace E_Commerce.Infrastructure.Extenstions
{
    public static class ServiceCollectionExtention
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("default");
            var companyConnectionString = configuration.GetConnectionString("company");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(companyConnectionString));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
