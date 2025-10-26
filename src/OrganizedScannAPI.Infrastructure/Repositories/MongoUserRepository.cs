using MongoDB.Driver;
using OrganizedScannApi.Domain.Entities;
using OrganizedScannApi.Domain.Repositories;
using OrganizedScannApi.Infrastructure.Data;

namespace OrganizedScannApi.Infrastructure.Repositories
{
    public class MongoUserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public MongoUserRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<User>("users");
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            return await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            var count = await _collection.CountDocumentsAsync(u => u.Email == email);
            return count > 0;
        }

        public async Task AddAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteAsync(long id)
        {
            await _collection.DeleteOneAsync(u => u.Id == id);
        }
    }
}

