using System.Collections.Generic;
using Market.Application.Products.DTO;

namespace Market.Application.Products.Queries
{
    public class GetProducts : IQuery<IEnumerable<ProductDto>>
    {
        public string Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}