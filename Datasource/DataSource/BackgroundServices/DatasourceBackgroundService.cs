using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using ServiceMesh;
namespace DataSource.BackgroundServices;

public class DatasourceBackgroundService :BackgroundService{
        private GrpcChannel _channel {get;set;}
        private   ServiceRegisterer.ServiceRegistererClient _client{get;set;}
        private ServiceInfo _serviceInfo  {get;set;}
        public bool isReady {get;set;} = false;
        public bool isRegistered {get;set;} = false;


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //http://localhost:5091
            while (!stoppingToken.IsCancellationRequested)
            {

                if(!isReady)
                {
                    var channel = GrpcChannel.ForAddress("http://127.0.0.1:5091");
                    _channel = channel;
                    try
                    {
                        var client = new ServiceRegisterer.ServiceRegistererClient(_channel);
                        _client = client;

                        var adapter = new ServiceAdapter {
                            Id ="80aFFca8-FFFF-4b20-b5de-FFF705497d4a",
                            Address =  "127.0.0.1",
                            ProtocolUsed= ProtocolUsed.WebApi,
                            ProtocolDescription= "/api",
                            ServiceInfoId =  "80aFFca8-664d-4b20-b5de-FFF705497d4a"};

                        var serviceInfo = new ServiceInfo() { Id = "80aFFca8-664d-4b20-b5de-FFF705497d4a"
                                , ServiceType = "DatasourceManager"
                                ,Timestamp=Timestamp.FromDateTime(DateTime.Now.ToUniversalTime())};
                        serviceInfo.Adapters.Add(adapter);

                        _serviceInfo = serviceInfo;
                        client.DeleteService(new ServiceId(){Id ="80aFFca8-664d-4b20-b5de-FFF705497d4a"});
                        client.RegisterService(serviceInfo);
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
                Console.WriteLine(_client.GetAll(new EmptyMessage()).Services);
                await Task.Delay(5000, stoppingToken); // Simulate some work, e.g., check for updates every 5 seconds
            }
        }
    }
