using MongoDB.Driver;
using OrganizedScannApi.Domain.Entities;
using OrganizedScannApi.Domain.Repositories;
using OrganizedScannApi.Infrastructure.Data;
using System.Linq.Expressions;

namespace OrganizedScannApi.Infrastructure.Repositories
{
    public class MongoMotorcycleRepository : IMotorcycleRepository
    {
        private readonly IMongoCollection<Motorcycle> _collection;

        public MongoMotorcycleRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Motorcycle>("motorcycles");
        }

        public async Task<IEnumerable<Motorcycle>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Motorcycle?> GetByIdAsync(long id)
        {
            return await _collection.Find(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Motorcycle motorcycle)
        {
            await _collection.InsertOneAsync(motorcycle);
        }

        public async Task UpdateAsync(Motorcycle motorcycle)
        {
            await _collection.ReplaceOneAsync(m => m.Id == motorcycle.Id, motorcycle);
        }

        public async Task DeleteAsync(long id)
        {
            await _collection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Motorcycle>> SearchAsync(Expression<Func<Motorcycle, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }
    }
}

