using System.Diagnostics;
using ServiceMesh.GrpcServices;
using ServiceMesh.RepositoryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceMesh.Extnesions;
using ServiceMesh.Service;

namespace ServiceMesh {
    public class Program
    {
        public static void Main(string[] args)
        {



            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682


            builder.Services.AddGrpc();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
           // builder.Services.AddDbContext<ServiceMeshDbContext>();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.ConfigureOpenTelemtryTrace("serviceMesh");

            var app = builder.Build();
            
            using var zz = new Activity("meshservice");

            zz.AddTag("aa","zz");

            // Configure the HTTP request pipeline.
            app.MapGrpcService<ServiceRegistererService>();
           // app.MapGrpcService<ServiceGetterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();

        }
    }
}