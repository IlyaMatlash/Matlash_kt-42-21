using laba1.Interfaces.WorkloadInterfaces;
using Microsoft.Extensions.DependencyInjection;
namespace laba1.ServiceExtensions
{
    public static class SevrviceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkloadService, WorkloadService>();
            return services;
        }
    }
}
