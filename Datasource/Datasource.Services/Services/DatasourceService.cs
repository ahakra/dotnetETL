using DataSource.Contracts;
using DataSource.Entities;

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

        // Log successful retrieval
        Console.WriteLine("Successfully retrieved all datasources.");
        
        return datasources;
    }
    catch (Exception ex)
    {
        // Log the exception
        Console.WriteLine( "Error while retrieving datasources." + ex);

            // Rethrow the exception or handle it as needed
            throw;
    }
}

public   void InsertDatasource(DatasourceEntity datasourceEntity)
{
    try
    {
        _repository.DatasourceRepository.InsertDatasource(datasourceEntity);  
    }
    catch (Exception ex)
    {
        // Log the exception
        Console.WriteLine( "Error while retrieving datasources services." );

        // Rethrow the exception or handle it as needed
        throw;
    }
}
}
