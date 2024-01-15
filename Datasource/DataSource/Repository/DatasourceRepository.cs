using DataSource.Contracts;
using DataSource.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataSource.Repository;

public class DatasourceRepository:MongoRepositoryBase<DatasourceEntity>,IDatasourceRepository {

    public DatasourceRepository(IOptions<DatasourceDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _collection = database.GetCollection<DatasourceEntity>(typeof(DatasourceEntity).Name);
       
    }
    
    public Task<IEnumerable<DatasourceEntity>> GetAllDatasources()
    {
      try
      {
          var datasources =  GetAll();
          return datasources;
      }
      catch (Exception ex)
      {
           // Log the exception or handle it as needed
           Console.WriteLine( "Error while retrieving datasources." + ex);
           throw;
      }
    }

    public async Task<DatasourceEntity> InsertDatasource(DatasourceEntity datasourceEntity)
    {
        try
        {
           return  await Insert(datasourceEntity);
        }
        catch (Exception ex)
        {
            Console.WriteLine( "Error while retrieving datasources repo" );
            throw;
        }
    }
    public async Task<int> DeleteOneAsync(ObjectId objectId)
    {
        try
        {
            return  await Delete(objectId);
        }
        catch (Exception ex)
        {
            Console.WriteLine( "Error while deleting datasources repo" );
            throw;
        }
    }
}