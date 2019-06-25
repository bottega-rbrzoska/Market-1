using System;
using System.Threading.Tasks;
using Market.Core.Entities;
using Market.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.EF.Repositories
{
    public class EfUserRepository : IUserRepository
    {
        private readonly MarketContext _context;

        public EfUserRepository(MarketContext context)
        {
            _context = context;
        }

        public Task<User> GetAsync(Guid id)
            => _context.Users.SingleOrDefaultAsync(p => p.Id == id);

        public Task<User> GetAsync(string email)
            => _context.Users.SingleOrDefaultAsync(p =>
                string.Equals(p.Email, email, StringComparison.InvariantCultureIgnoreCase));

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}