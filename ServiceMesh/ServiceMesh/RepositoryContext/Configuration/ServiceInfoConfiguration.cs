using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServiceMesh;
using ServiceMesh.Entities;

namespace ServiceMesh.RepositoryContext.Configuration
{

    public class ServiceInfoConfiguration : IEntityTypeConfiguration<ServiceInfoEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceInfoEntity> builder)
        {
            builder.ToTable("ServiceInfos");

            // Configure primary key, properties, relationships, etc.

            // Add sample data
            builder.HasData(
                new ServiceInfoEntity { Id = "80abbca8-664d-4b20-b5de-024705497d4a", ServiceType = "LoggerService" ,Timestamp=DateTime.Now},
                new ServiceInfoEntity { Id = "80abbca8-664d-4b20-b5de-024705497d5b", ServiceType = "AuthenticationService", Timestamp = DateTime.Now }
            );
        }
    }
}
