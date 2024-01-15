using DataSource.Entities;
namespace DataSource.Contracts;

public interface IDatasourceRepository {
    Task<IEnumerable<DatasourceEntity>> GetAllDatasources();
    void InsertDatasource(DatasourceEntity datasourceEntity);
}