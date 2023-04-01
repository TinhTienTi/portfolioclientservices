﻿using Microsoft.Extensions.Configuration;
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

        public async Task<IEnumerable<ProfileResponseDto>> GetAboutInfoQueryableAsync(string languageId)
        {
            try
            {
                var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ProfileResponseDto>>>();

                IEnumerable<ProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:About"]);

                return result;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<ClientProfileResponseDto>> GetClientInfoQueryableAsync(string languageId)
        {
            try
            {
                var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ClientProfileResponseDto>>>();

                IEnumerable<ClientProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Client"]);

                return result;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<ProfileResponseDto>> GetHomeInfoQueryableAsync(string languageId)
        {
            var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ProfileResponseDto>>>();

            IEnumerable<ProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Home"]);

            return result;
        }

        public async Task<IEnumerable<ServiceProfileResponseDto>> GetServicesInfoQueryableAsync(string languageId)
        {
            var xx = serviceProvider.GetService<IPingApiService<IEnumerable<ServiceProfileResponseDto>>>();

            IEnumerable<ServiceProfileResponseDto> result = await xx.GetAsync(configuration["ProfileUrl:Service"]);

            return result;
        }
    }
}
