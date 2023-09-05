using Hr.LeaveManagement.Persistence.DatabaseContext;
using Hr.LeaveManagement.Persistence.Repositories;
using Hr.LeaveMangement.Application.Contracts.Persistence;
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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            return services;
        }
    }

}