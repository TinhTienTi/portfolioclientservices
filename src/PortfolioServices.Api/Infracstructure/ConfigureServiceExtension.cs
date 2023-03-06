using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PortfolioServices.Context;
using PortfolioServices.Context.Interfaces;
using PortfolioServices.Model.Others;

namespace PortfolioServices.Api.Infracstructure
{
    public static class ConfigureServiceExtension
    {
        public static void AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProfiles();

            services.AddMongoDbContext(configuration);

            services.AddApplicationControllers();

            services.AddSwagger();
        }

        private static void AddProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PortfolioServices.Profiles.MappingProfile));
        }

        private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoConnection"));

            services.AddScoped<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped(typeof(IGenericDAL<>), typeof(GenericDAL<>));
        }

        private static void AddApplicationControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }
    }
}
