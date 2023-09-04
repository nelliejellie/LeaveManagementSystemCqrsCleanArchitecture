using Hr.LeaveManagement.Infrastructure.EmailService;
using Hr.LeaveManagement.Infrastructure.Logger;
using Hr.LeaveMangement.Application.Contracts.Email;
using Hr.LeaveMangement.Application.Logger;
using Hr.LeaveMangement.Application.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Hr.LeaveManagement.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}