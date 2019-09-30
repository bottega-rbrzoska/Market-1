using System;
using System.Threading.Tasks;
using Market.Core.Entities;

namespace Market.Core.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetAsync(Guid id);
        Task AddAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}