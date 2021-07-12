using System;
using System.Threading.Tasks;
using DevMeetings.Services.Users.Core.Entities;

namespace DevMeetings.Services.Users.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetByIdAsync(Guid id);
    }
}