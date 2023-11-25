using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure
{
    public static class AddInfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(IServiceCollection services, IConfiguration configuration)
        {

            //at first create appsettings.json
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient(typeof(IEmailSender), typeof(EmailSender));
            return services;
        }

    }
}