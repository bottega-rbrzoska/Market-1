using System;
using Market.Application.Products.DTO;

namespace Market.Application.Products.Queries
{
    public class GetProduct : IQuery<ProductDetailsDto>
    {
        public Guid Id { get; set; }
    }
}