using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ServiceMesh.Entities;

namespace ServiceMesh.RepositoryContext.Configuration
{

    public class ServiceAdapterConfiguration : IEntityTypeConfiguration<ServiceAdapterEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceAdapterEntity> builder)
        {
            builder.ToTable("ServiceAdapters");

            // Configure primary key, properties, relationships, etc.

            // Add sample data
            builder.HasData(
                new ServiceAdapterEntity { Id = "90abbca8-664d-4b20-b5de-024705497d4a",
                    Address = "127.0.0.1",
                    ProtocolUsed = ProtocolUsedEnum.HTTP,
                    ProtocolDescription = "/api",
                    ServiceInfoEntityId = "80abbca8-664d-4b20-b5de-024705497d4a" },

                new ServiceAdapterEntity { Id =  "91abbca8-664d-4b20-b5de-024705497d4a",
                    Address = "localhost:50051",
                    ProtocolUsed = ProtocolUsedEnum.Kafka, 
                    ProtocolDescription = "com.example.Greeter/SayHello",
                    ServiceInfoEntityId = "80abbca8-664d-4b20-b5de-024705497d4a" },


                new ServiceAdapterEntity { Id = "92abbca8-664d-4b20-b5de-024705497d4a",
                    Address = "127.0.0.2", 
                    ProtocolUsed = ProtocolUsedEnum.Kafka,
                    ProtocolDescription = "/api",
                    ServiceInfoEntityId = "80abbca8-664d-4b20-b5de-024705497d5b"},
                new ServiceAdapterEntity { Id = "93abbca8-664d-4b20-b5de-024705497d4a",
                    Address = "localhost:50053", 
                    ProtocolUsed = ProtocolUsedEnum.gRPC, 
                    ProtocolDescription = "com.example.Greeter/SayHello", 
                    ServiceInfoEntityId = "80abbca8-664d-4b20-b5de-024705497d5b" }
            );

        }
    }

}
