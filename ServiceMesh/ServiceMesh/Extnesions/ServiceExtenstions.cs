using ServiceMesh.Contracts;
using ServiceMesh.Contracts.Service;
using ServiceMesh.Repository;
using ServiceMesh.RepositoryContext;
using ServiceMesh.Service;


namespace ServiceMesh.Extnesions;

public static class ServiceExtenstions {
    public static void ConfigureRepositoryManager(this IServiceCollection services)
        => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();


    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) 
        => services.AddSqlServer<ServiceMeshDbContext>((configuration.GetConnectionString("sqlConnection")));
}