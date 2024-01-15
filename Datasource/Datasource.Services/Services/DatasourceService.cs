using DataSource.Contracts;
using DataSource.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataSource.Services.Services;
public class DatasourceService:IDatasourceService {

    private readonly IRepositoryManager _repository;

    public DatasourceService(IRepositoryManager repository) {
        _repository = repository;

    }
    public Task<IEnumerable<DatasourceEntity>> GetAllDatasources()
    {
        try
        {
            var datasources =  _repository.DatasourceRepository.GetAllDatasources();
            Console.WriteLine("Successfully retrieved all datasources.");
            return datasources;
        }
        catch (Exception ex)
        {
            Console.WriteLine( "Error while retrieving datasources." + ex);
            throw;
        }
    }

    public async Task<DatasourceEntity>  InsertDatasource(DatasourceEntity datasourceEntity)
    {
        try
        {
            return await _repository.DatasourceRepository.InsertDatasource(datasourceEntity);
        }
        catch (Exception ex)
        {
            Console.WriteLine( "Error while retrieving datasources services." );
            throw;
        }
    }
    public async Task<bool> DeleteDatasource(string datasourceId)
    {
        var objectId = new ObjectId(datasourceId);
        var deleteResult = await _repository.DatasourceRepository.DeleteOneAsync(objectId);
        return deleteResult > 0;
    }
}
