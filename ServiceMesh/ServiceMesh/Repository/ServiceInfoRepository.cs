using ServiceMesh.Contracts;
using ServiceMesh.Entities;
using ServiceMesh.RepositoryContext;
using ServiceMesh;
using Microsoft.EntityFrameworkCore;

namespace ServiceMesh.Repository
{
    public class ServiceInfoRepository :RepositoryBase<ServiceInfoEntity>,IServiceInfoRepository
    {
        public ServiceInfoRepository(ServiceMeshDbContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<ServiceInfoEntity> GetAllServiceInfo(bool trackChanges)
        {
            return FindAll(trackChanges).Include(si => si.Adapters).OrderBy(c => c.ServiceType).ToList();

        }

        public IEnumerable<ServiceInfoEntity> GetByType(serviceType serviceType, bool trackChanges)
        {
            return FindByCondition(e=>e.ServiceType.Equals(serviceType.Type),trackChanges).Include(si => si.Adapters).OrderBy(c => c.ServiceType).ToList();
        }

        public ServiceInfoEntity GetById(ServiceId serviceId, bool trackChanges)
        {
          //  return FindByCondition(e=>e.Id.Equals(new Guid(serviceId.Id)),trackChanges).FirstOrDefault();
                return FindByCondition(e=>e.Id.Equals(serviceId.Id),trackChanges).FirstOrDefault();
        }

        public void DeleteService(ServiceInfoEntity service,bool trackChanges)
        {

             Delete(service);
        }

        public void UpdateService(ServiceInfoEntity service, bool trackChanges)
        {
            Update(service);
        }

        public void RegisterService(ServiceInfoEntity service,bool trackChanges)
        {
                Create(service);

        }
    }
}
