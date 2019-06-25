using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.DTO;
using Market.Application.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.EF.Queries
{
    public class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
    {
        private readonly MarketContext _context;

        public GetProductsHandler(MarketContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts query)
        {
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Category))
            {
                products = products.Where(p => p.Category == query.Category);
            }

            if (query.MinPrice.HasValue)
            {
                products = products.Where(p => p.Price >= query.MinPrice);
            }

            if (query.MaxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= query.MaxPrice);
            }

            return await products.Select(p => new ProductDto(p)).ToListAsync();
        }
    }
}