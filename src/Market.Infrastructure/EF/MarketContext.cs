using Market.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Market.Infrastructure.EF
{
    public class MarketContext : DbContext
    {
        private readonly IOptions<EfOptions> _options;
        
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public MarketContext(IOptions<EfOptions> options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            if (_options.Value.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("Market");
                return;
            }

            optionsBuilder.UseSqlServer(_options.Value.ConnectionString);
        }
    }
}