using System;
using System.Threading.Tasks;
using Market.Core.Entities;

namespace Market.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task CreateAsync(User user);
    }
}