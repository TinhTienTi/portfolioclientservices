using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioServices.Bo.ApiServices;
using PortfolioServices.Bo.Interfaces;
using PortfolioServices.Model;

namespace PortfolioServices.Bo
{
    public class ProfileBo : IProfileBo
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IConfiguration configuration;

        public ProfileBo(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<HomeProfileResponse>> GetHomeInfoQueryableAsync(string languageId)
        {
            var xx = serviceProvider.GetService<IPingApiService<IEnumerable<HomeProfileResponse>>>();

            IEnumerable<HomeProfileResponse> result = await xx.GetAsync(configuration["ProfileUrl:Home"]);

            return result;
        }
    }
}
