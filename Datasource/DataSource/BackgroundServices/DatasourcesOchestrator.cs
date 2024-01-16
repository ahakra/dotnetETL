using DataSource.Services.Services;
using DataSource.Contracts;

namespace DataSource.BackgroundServices;

public class DatasourcesOchestrator :BackgroundService{
    private readonly IServiceManager _service;
    public DatasourcesOchestrator(IServiceManager service) => _service = service;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        while (!stoppingToken.IsCancellationRequested)
        {
            var allDatasources = _service.DatasourceService.GetAllDatasources();
            foreach(var datasource in allDatasources.Result)
            {
                Console.WriteLine(datasource);
            }
            await  Task.Delay(5000);
        }
    }
}