using AutoMapper;
using ServiceMesh.Contracts;
using ServiceMesh.Contracts.Service;

namespace ServiceMesh.Service
{
    public sealed class ServiceManager:IServiceManager
    {
        
        private readonly Lazy<IServiceInfoService> _serviceInfoService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _serviceInfoService = new Lazy<IServiceInfoService>(() => new ServiceInfoService(repositoryManager,mapper));
        }   


        public IServiceInfoService ServiceInfoService => _serviceInfoService.Value;
    }
}
