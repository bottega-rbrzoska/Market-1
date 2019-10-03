using System;
using Market.Core.Entities;

namespace Market.Application.Products.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public ProductDto()
        {
        }
        
        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Category = product.Category;
            Price = product.Price;
        }
    }
}