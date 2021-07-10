using System.Threading.Tasks;
using DevMeetings.Services.Users.Core.Entities;
using DevMeetings.Services.Users.Core.Repositories;
using MongoDB.Driver;

namespace DevMeetings.Services.Users.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<User>("users");
        }
        public async Task AddAsync(User user)
        {
            await _collection.InsertOneAsync(user);
        }
    }
}