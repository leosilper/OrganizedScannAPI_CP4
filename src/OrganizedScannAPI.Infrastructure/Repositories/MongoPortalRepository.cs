using MongoDB.Driver;
using OrganizedScannApi.Domain.Entities;
using OrganizedScannApi.Domain.Repositories;
using OrganizedScannApi.Infrastructure.Data;

namespace OrganizedScannApi.Infrastructure.Repositories
{
    public class MongoPortalRepository : IPortalRepository
    {
        private readonly IMongoCollection<Portal> _collection;

        public MongoPortalRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Portal>("portals");
        }

        public async Task<IEnumerable<Portal>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Portal?> GetByIdAsync(long id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Portal portal)
        {
            await _collection.InsertOneAsync(portal);
        }

        public async Task UpdateAsync(Portal portal)
        {
            await _collection.ReplaceOneAsync(p => p.Id == portal.Id, portal);
        }

        public async Task DeleteAsync(long id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}

