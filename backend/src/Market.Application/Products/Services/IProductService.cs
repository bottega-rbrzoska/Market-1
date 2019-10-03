using System;
using System.Threading.Tasks;
using Market.Application.Products.DTO;

namespace Market.Application.Products.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetAsync(Guid id);
        Task CreateAsync(ProductDetailsDto dto);
    }
}