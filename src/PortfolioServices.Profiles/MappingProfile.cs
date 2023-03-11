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

            CreateMap<Categories, CategoriesDto>();
            CreateMap<CategoriesDto, Categories>();

            CreateMap<Home, LanguageDto>();
            CreateMap<LanguageDto, Home>();

            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();
        }
    }
}