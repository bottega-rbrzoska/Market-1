using System;
using System.Threading.Tasks;
using Market.Core.Entities;
using Market.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.EF.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly MarketContext _context;

        public EfProductRepository(MarketContext context)
        {
            _context = context;
        }

        public Task<Product> GetAsync(Guid id)
            => _context.Products.SingleOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await GetAsync(id);
            if (product is null)
            {
                return;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}