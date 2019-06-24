using Market.Application;
using Market.Application.Products.Commands;
using Market.Application.Products.Commands.Handlers;
using Market.Application.Products.Services;
using Market.Core.Repositories;
using Market.Infrastructure.Caching.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }
            
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            services.Configure<AppOptions>(configuration.GetSection("app"));
            services.AddTransient<IProductService, ProductService>();
//            services.AddTransient<ICommandHandler<CreateProduct>, CreateProductHandler>();

            services.Scan(s => s.FromAssemblyOf<ICommand>()
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}