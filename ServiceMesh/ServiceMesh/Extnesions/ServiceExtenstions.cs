using ServiceMesh.Contracts;
using ServiceMesh.Contracts.Service;
using ServiceMesh.Repository;
using ServiceMesh.RepositoryContext;
using ServiceMesh.Service;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter.Zipkin;

namespace ServiceMesh.Extnesions;

public static class ServiceExtenstions {
    public static void ConfigureRepositoryManager(this IServiceCollection services)
        => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();


    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) 
        => services.AddSqlServer<ServiceMeshDbContext>((configuration.GetConnectionString("sqlConnection")));

    public static void ConfigureOpenTelemtryTrace(this IServiceCollection services, string serviceName)
    {

        services.AddOpenTelemetry()

            .ConfigureResource(resource => resource.AddService(serviceName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
            .AddGrpcClientInstrumentation()
          //  .AddConsoleExporter());
                .AddZipkinExporter(options =>
                {
                    options.Endpoint = new Uri("http://localhost:9411/api/v2/spans");
                }));

    }

}