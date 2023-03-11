using PortfolioServices.Bo;
using PortfolioServices.Bo.ApiServices;
using PortfolioServices.Bo.Interfaces;

namespace PortfolioServices.Client.Infracstructure.Extensions
{
    public static class ConfigureServiceExtension
    {
        public static void AddConfigureServiceExtension(this IServiceCollection services)
        {
            services.AddApiService();

            services.AddBussiness();
        }

        private static void AddApiService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPingApiService<>), typeof(PingApiService<>));
        }

        private static void AddBussiness(this IServiceCollection services)
        {
            services.AddScoped<IProfileBo, ProfileBo>();
        }
    }
}
