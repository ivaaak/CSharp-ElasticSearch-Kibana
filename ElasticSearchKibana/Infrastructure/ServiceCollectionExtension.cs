using Microsoft.OpenApi.Models;
using Nest;

namespace ElasticSearchKibana.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwaggerAndElasticSearch(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElasticSearchKibana", Version = "v1" });
            });

            var settings = new ConnectionSettings();
            services.AddSingleton<IElasticClient>(new ElasticClient(settings));

            return services;
        }
    }
}