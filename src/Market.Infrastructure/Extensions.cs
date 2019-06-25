using System;
using Market.Application;
using Market.Application.Products.Services;
using Market.Application.Users.Services;
using Market.Infrastructure.Auth;
using Market.Infrastructure.Dispatchers;
using Market.Infrastructure.EF;
using Market.Infrastructure.Jobs;
using Microsoft.AspNetCore.Identity;
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

//            services.AddSingleton<IProductRepository, InMemoryProductRepository>();
            services.Configure<AppOptions>(configuration.GetSection("app"));
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<IDispatcher, InMemoryDispatcher>();
            services.AddHostedService<NotifyUsersJob>();
            services.AddJwt();
            services.AddAuthorization(a => a.AddPolicy("admin", p => p
                .RequireAuthenticatedUser()
                .RequireRole("admin")));
            services.AddEntityFramework();
            services.Scan(s => s.FromAssemblyOf<ICommand>()
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}