using DataSource.Contracts;
using DataSource.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataSource.Repository;

public class DatasourceRepository:MongoRepositoryBase<DatasourceEntity>,IDatasourceRepository {
    static bool PingDatabase(IMongoDatabase database)
    {
        try
        {
            // Ping the server to check the connection
            database.RunCommand((Command<BsonDocument>)"{ ping: 1 }");
            return true;
        }
        catch (MongoConnectionException)
        {
            // Exception occurred, indicating a connection issue
            return false;
        }
    }
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

// Rethrow the exception or return a default value, depending on your needs
throw;
       }
    }
    
    public void InsertDatasource(DatasourceEntity datasourceEntity)
    {
        try
        {
            InsertDatasource(datasourceEntity);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine( "Error while retrieving datasources repo" );

            // Rethrow the exception or return a default value, depending on your needs
            throw;
        }
    }
}