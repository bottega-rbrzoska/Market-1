using System;
using System.Threading;
using System.Threading.Tasks;
using Market.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Market.Infrastructure.Jobs
{
    public class NotifyUsersJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotifyUsersJob> _logger;

        public NotifyUsersJob(IServiceProvider serviceProvider,
            ILogger<NotifyUsersJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Notifying users...");
                using (var scope = _serviceProvider.CreateScope())
                {
                    var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
                    // ...
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}