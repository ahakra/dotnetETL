using DataSource.Contracts;
using DataSource.Entities;
namespace DataSource.Repository;
using Microsoft.Extensions.Options;

public class RepositoryManager:IRepositoryManager {
   
    private readonly IOptions<DatasourceDatabaseSettings> _datasourceDatabaseSettomgs;
    private readonly Lazy<IDatasourceRepository> _datasourceoRepository;
   
    public RepositoryManager(IOptions<DatasourceDatabaseSettings> datasourceDatabaseSettings) {

        _datasourceDatabaseSettomgs = datasourceDatabaseSettings;
        _datasourceoRepository = new Lazy<IDatasourceRepository> (()=> new DatasourceRepository(datasourceDatabaseSettings));
    }

    public  IDatasourceRepository DatasourceRepository => _datasourceoRepository.Value;


}