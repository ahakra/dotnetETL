using ServiceMesh.Entities;

namespace ServiceMesh.Contracts.Service
{
    public interface IServiceInfoService
    {
        IEnumerable<ServiceInfo> GetAllServiceInfo(bool trackChanges);
        IEnumerable<ServiceInfo> GetByType(serviceType serviceType,bool trackChanges);
        ResponseMessage DeleteService(ServiceId request,bool trackChanges);
        ResponseMessage UpdateService(ServiceId request,bool trackChanges);
        ResponseMessage RegisterService(ServiceInfo request,bool trackChanges);
    }
}
