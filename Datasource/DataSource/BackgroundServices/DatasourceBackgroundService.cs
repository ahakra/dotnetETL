using Grpc.Net.Client;
using ServiceMesh;
using DataSource.BackgroundServices.Entities;
using DataSource.BackgroundServices.Contracts;
using Microsoft.Extensions.Options;

namespace DataSource.BackgroundServices;

public class DatasourceManagerBackgroundService :BackgroundService{

        private   GrpcChannel _channel{get;}
        private   ServiceRegisterer.ServiceRegistererClient _client{get;}
        private ServiceInfo _serviceInfo {get;set;}
        private readonly IDatasourceInitiliazer _dataSourceManagerInitializer;

        public bool isReady {get;set;} = false;
        public bool isRegistered {get;set;} = false;

        public DatasourceManagerBackgroundService(IOptions<DataSourceManagerInitializer> dataSourceManagerInitializerOptions)
        {
                _dataSourceManagerInitializer = dataSourceManagerInitializerOptions.Value;
                _channel =GrpcChannel.ForAddress(_dataSourceManagerInitializer.GrpcURl);
                _client = new ServiceRegisterer.ServiceRegistererClient(_channel);
                _serviceInfo = _dataSourceManagerInitializer.ServiceInfo;
                _serviceInfo.Adapters.Add(_dataSourceManagerInitializer.ServiceAdapter);

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                if(!isReady)
                {
                    try
                    {
                        _client.DeleteService(new ServiceId(){Id = _serviceInfo.Id});
                        _client.RegisterService(_serviceInfo);

                        isReady = true;
                        isRegistered = true;
                    }
                    catch (Exception ex)   {
                           Console.WriteLine($"Error: {ex}");
                           isReady = false;
                           isRegistered = false;  }

                }

                if(isReady && isRegistered)
                {
                    _client.UpdateService(new ServiceId(){Id = _serviceInfo.Id});
                    Console.WriteLine("updating datasource manager");
                }
              
                await Task.Delay(5000, stoppingToken); // Simulate some work, e.g., check for updates every 5 seconds
            }
        }
    }
