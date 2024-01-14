using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading;
using System.Threading.Tasks;

namespace DataSource.BackgroundServices;

public class DatasourceBackgroundService :BackgroundService{
 
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Background service is running...");

                // Your background service logic goes here

                await Task.Delay(5000, stoppingToken); // Simulate some work, e.g., check for updates every 5 seconds
            }
        }
    }
