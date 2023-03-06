namespace PortfolioServices.Api.Infracstructure
{
    public static class ConfigureServiceExtension
    {
        public static void AddConfigureServices(this IServiceCollection services)
        {
            services.AddProfiles();

            services.AddApplicationControllers();

            services.AddSwagger();
        }

        private static void AddProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PortfolioServices.Profiles.MappingProfile));
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
