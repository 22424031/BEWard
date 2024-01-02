using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ward.Application.Contracts.Ward;

namespace GOVInforService
{
    public static class GOVInforServiceRegistration
    {
        public static IServiceCollection ConfigGOVInforService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGovInforAds, GOVInforAds>();
            return services;
        }
    }
}