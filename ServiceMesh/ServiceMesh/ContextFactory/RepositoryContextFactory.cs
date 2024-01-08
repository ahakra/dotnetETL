using ServiceMesh.RepositoryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ServiceMesh.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<ServiceMeshDbContext>
    {
        public ServiceMeshDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
                .Build(); var builder = new DbContextOptionsBuilder<ServiceMeshDbContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            return new ServiceMeshDbContext(builder.Options);
        }


    }
}
