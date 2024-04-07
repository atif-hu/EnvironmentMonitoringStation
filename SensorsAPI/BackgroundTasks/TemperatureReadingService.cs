using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SensorsAPI.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SensorsAPI.Services
{
    public class TemperatureReadingService : BackgroundService
    {
        private readonly IServiceProvider _services;

        public TemperatureReadingService(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var temperatureSensorController = scope.ServiceProvider.GetRequiredService<TemperatureSensorController>();
                    await temperatureSensorController.GetTemperature();

                    // Wait for 1 minute before next iteration
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
            }
        }
    }
}
