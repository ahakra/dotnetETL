using ServiceMesh;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceMesh.Entities
{
    
  
    
    public class ServiceAdapterEntity
    {
        public String Id { get; set; }
        public string Address { get; set; }
        public ProtocolUsedEnum ProtocolUsed { get; set; }
        public string ProtocolDescription { get; set; }

        // Foreign key to link with ServiceInfoEntity
        [ForeignKey(nameof(ServiceInfoEntity))]
        public string ServiceInfoEntityId { get; set; }

        // Navigation property to represent the parent ServiceInfoEntity
        public ServiceInfoEntity? ServiceInfoEntity { get; set; }
    }
}

