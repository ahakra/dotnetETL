using ServiceMesh.Contracts;
using ServiceMesh.RepositoryContext;

namespace ServiceMesh.Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly ServiceMeshDbContext _repositoryContext;

        private readonly Lazy<IServiceInfoRepository> _serviceInfoRepository;
        public RepositoryManager(ServiceMeshDbContext repositoryContext) {
        
        _repositoryContext = repositoryContext;

        _serviceInfoRepository = new Lazy<IServiceInfoRepository> (()=> new ServiceInfoRepository(repositoryContext));
        
        
        }

        public  IServiceInfoRepository ServiceInfo => _serviceInfoRepository.Value;
        
        public void Save() => _repositoryContext.SaveChanges();


    }
}
