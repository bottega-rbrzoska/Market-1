using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Core.Entities;
using Market.Core.Repositories;

namespace Market.Infrastructure.Caching.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Huawei P30", "Phones", "Lorem ipsum...", 3500),
            new Product(Guid.NewGuid(), "IPhone X", "Phones", "Lorem ipsum...", 5000),
            new Product(Guid.NewGuid(), "Dell XPS 15", "Notebooks", "Lorem ipsum...", 8500)
            
        };

        public Task<Product> GetAsync(Guid id)
            => Task.FromResult(_products.SingleOrDefault(p => p.Id == id));

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await GetAsync(id);
            if (product is null)
            {
                return;
            }

            _products.Remove(product);
        }
    }
}