using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioServices.Bo.ApiServices;
using PortfolioServices.Bo.Interfaces;
using PortfolioServices.Dto;

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

        public async Task<IEnumerable<ProfileResponseDto>> GetAboutInfoAsync(string languageId)
        {
            try
            {
                var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ProfileResponseDto>>>();

                IEnumerable<ProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:About"]);

                return result;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<ClientProfileResponseDto>> GetClientInfoAsync(string languageId)
        {
            try
            {
                var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ClientProfileResponseDto>>>();

                IEnumerable<ClientProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Client"]);

                return result;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<ProfileResponseDto>> GetHomeInfoAsync(string languageId)
        {
            var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ProfileResponseDto>>>();

            IEnumerable<ProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Home"]);

            return result;
        }

        public async Task<IEnumerable<PortfolioProfileResponseDto>> GetPortfolioInfoAsync(string languageId)
        {
            var xx = serviceProvider.GetService<IPingApiService<IEnumerable<PortfolioProfileResponseDto>>>();

            IEnumerable<PortfolioProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Portfolio"]);

            return result;
        }

        public async Task<IEnumerable<ServiceProfileResponseDto>> GetServicesInfoAsync(string languageId)
        {
            var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ServiceProfileResponseDto>>>();

            IEnumerable<ServiceProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Service"]);

            return result;
        }
    }
}
