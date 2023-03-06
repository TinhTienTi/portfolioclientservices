using AutoMapper;
using PortfolioServices.Dto;
using PortfolioServices.Model;

namespace PortfolioServices.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherForecastDto, WeatherForecast>();
            CreateMap<WeatherForecast, WeatherForecastDto>();
        }
    }
}