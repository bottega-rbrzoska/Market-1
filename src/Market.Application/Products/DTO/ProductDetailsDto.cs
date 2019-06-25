using Market.Core.Entities;

namespace Market.Application.Products.DTO
{
    public class ProductDetailsDto : ProductDto
    {
        public string Description { get; set; }

        public ProductDetailsDto()
        {
        }

        public ProductDetailsDto(Product product) : base(product)
        {
            Description = product.Description;
        }
    }
}