using ServiceMesh.Entities;

namespace ServiceMesh.Contracts
{
    public interface IServiceInfoRepository
    {
        IEnumerable<ServiceInfoEntity> GetAllServiceInfo(bool trackChanges);
        IEnumerable<ServiceInfoEntity> GetByType(serviceType serviceType,bool trackChanges);
        ServiceInfoEntity GetById(ServiceId serviceId, bool trackChanges);
        void DeleteService(ServiceInfoEntity service,bool trackChanges);
        void UpdateService(ServiceInfoEntity service,bool trackChanges);
        void RegisterService(ServiceInfoEntity service,bool trackChanges);

    }
}
