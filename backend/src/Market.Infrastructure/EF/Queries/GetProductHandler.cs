using System.Threading.Tasks;
using Market.Application;
using Market.Application.Products.DTO;
using Market.Application.Products.Queries;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.EF.Queries
{
    public class GetProductHandler : IQueryHandler<GetProduct, ProductDetailsDto>
    {
        private readonly MarketContext _context;

        public GetProductHandler(MarketContext context)
        {
            _context = context;
        }

        public async Task<ProductDetailsDto> HandleAsync(GetProduct query)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == query.Id);

            return product is null ? null : new ProductDetailsDto(product);
        }
    }
}