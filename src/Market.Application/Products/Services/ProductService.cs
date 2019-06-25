using System;
using System.Threading.Tasks;
using Market.Application.Products.DTO;
using Market.Core.Entities;
using Market.Core.Repositories;

namespace Market.Application.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            return product is null ? null : new ProductDto(product);
        }

        public async Task CreateAsync(ProductDetailsDto dto)
        {
            var product = new Product(dto.Id, dto.Name, dto.Category, dto.Description, dto.Price);
            await _productRepository.AddAsync(product);
        }
    }
}