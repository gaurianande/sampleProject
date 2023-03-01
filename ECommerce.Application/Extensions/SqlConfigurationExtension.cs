using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application.Extensions
{
    public static class SqlConfigurationExtension
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }
    }
}
