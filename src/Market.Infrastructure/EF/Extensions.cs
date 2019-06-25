using Market.Core.Repositories;
using Market.Infrastructure.EF.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            services.AddTransient<IProductRepository, EfProductRepository>();
            services.AddTransient<IUserRepository, EfUserRepository>();
            services.Configure<EfOptions>(configuration.GetSection("ef"));
            services.AddEntityFrameworkSqlServer()
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<MarketContext>();
            
            return services;
        }
    }
}