
using AutoMapper.Internal;
using Hr.LeaveManagement.Domain.DTOs.RequestDto;
using Hr.LeaveManagement.Domain.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveManagement.Domain.Features.LeaveTypeArea.Queries.GetAllLeaveTypes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hr.LeaveMangement.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IRequestHandler<GetAllLeaveTypesQuery, List<LeaveTypeDto>>, GetAllLeaveTypesHandler>();
            //services.AddTransient(typeof(IPipelineBehavior<,>));
            //services.AddMediatR(cfg => cfg.(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
