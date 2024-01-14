using ServiceMesh.Entities;
using ServiceMesh.GrpcServices;
using ServiceMesh.RepositoryContext.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ServiceMesh.RepositoryContext
{
    public class ServiceMeshDbContext : DbContext
    {
        public ServiceMeshDbContext(DbContextOptions options) : base(options) { }

        protected  override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.ApplyConfiguration(new ServiceAdapterConfiguration()); 
            modelBuilder.ApplyConfiguration(new ServiceInfoConfiguration());
        }
        public DbSet<ServiceAdapterEntity> ServiceAdapter { get; set; }
        public DbSet<ServiceInfoEntity> ServiceInfo { get; set; }
    }
}
