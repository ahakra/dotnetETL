using DataSource.Entities;
using MongoDB.Bson;

namespace DataSource.Contracts;

public interface IDatasourceService {
   Task<IEnumerable<DatasourceEntity>> GetAllDatasources();
   Task<DatasourceEntity>  InsertDatasource(DatasourceEntity datasourceEntity);
   Task<bool> DeleteDatasource(string datasourceId);
 
}