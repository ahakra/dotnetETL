using DataSource.Contracts;

namespace DataSource.Services;

public class ServiceManager:IServiceManager {
    private readonly Lazy<IDatasourceService> _datasourceService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {

        _datasourceService = new Lazy<IDatasourceService>(() => new DatasourceService(repositoryManager));
    }   
    public IDatasourceService DatasourceService => _datasourceService.Value;
}