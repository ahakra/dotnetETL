
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataSource.Entities;

public class DatasourceEntity {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}
    public string Mapper {get;set;}
    
    public bool IsActive {get;set;}
    public AdapterEntity Adapter { get; set; }
}