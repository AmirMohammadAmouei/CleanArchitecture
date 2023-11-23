using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DataBaseContext;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<HRDataBaseContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
            services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));
            services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));

            return services;
        }
    }
}
