using DataSource.Entities;

namespace DataSource.Contracts;

public interface IDatasourceService {
   Task<IEnumerable<DatasourceEntity>> GetAllDatasources();
   void InsertDatasource(DatasourceEntity datasourceEntity);
}