using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataSource.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class AdapterEntity {
//    [BsonId]
//    [BsonRepresentation(BsonType.ObjectId)]
//    public string Id {get;set;}
    public string IpAdd {get;set;}
    public int Port {get;set;}
    public string Directory {get;set;}
    public string ProcessedDirectory  {get;set;}
    public string InvalidDirectory {get;set;}
    public string NameRegex {get;set;}
   
}