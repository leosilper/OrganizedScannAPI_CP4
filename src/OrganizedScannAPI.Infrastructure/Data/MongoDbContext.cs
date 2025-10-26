using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace OrganizedScannApi.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDB") 
                ?? configuration["MongoDB:ConnectionString"] 
                ?? "mongodb://localhost:27017";

            var databaseName = configuration["MongoDB:DatabaseName"] 
                ?? "OrganizedScannDB";

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase Database => _database;
    }
}

