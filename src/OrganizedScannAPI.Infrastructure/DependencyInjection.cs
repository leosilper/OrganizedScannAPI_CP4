using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using OrganizedScannApi.Domain.Repositories;
using OrganizedScannApi.Infrastructure.Data;
using OrganizedScannApi.Infrastructure.Repositories;

namespace OrganizedScannApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // MongoDB Configuration
            services.AddSingleton<MongoDbContext>();
            
            // Repositories
            services.AddScoped<IMotorcycleRepository, MongoMotorcycleRepository>();
            services.AddScoped<IPortalRepository, MongoPortalRepository>();
            services.AddScoped<IUserRepository, MongoUserRepository>();

            // Health Checks
            var mongoConnectionString = config.GetConnectionString("MongoDB") 
                ?? config["MongoDB:ConnectionString"] 
                ?? "mongodb://localhost:27017";

            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddMongoDb(
                    mongoConnectionString, 
                    name: "mongodb",
                    tags: new[] { "mongodb", "database" });

            return services;
        }
    }
}
