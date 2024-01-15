using DataSource.Entities;
using MongoDB.Bson;
namespace DataSource.Contracts;


public interface IDatasourceRepository {
    Task<IEnumerable<DatasourceEntity>> GetAllDatasources();
    Task<DatasourceEntity> InsertDatasource(DatasourceEntity datasourceEntity);
    Task<int> DeleteOneAsync(ObjectId objectId);
}