using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBConnection")));
            return services;
        }

        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IServiceRepository, ServiceRepository>();
            return services;
        }
    }
}
