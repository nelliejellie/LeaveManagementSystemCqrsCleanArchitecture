using Hr.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.LeaveManagement.Persistence
{
    public static class PersistenceServiceRegisteration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
            });
            return services;
        }
    }

}