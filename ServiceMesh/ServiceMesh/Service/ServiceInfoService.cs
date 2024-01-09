using AutoMapper;
using ServiceMesh.Contracts;
using ServiceMesh.Contracts.Service;
using ServiceMesh.Entities;
using System.Diagnostics;
using ServiceMesh;

namespace ServiceMesh.Service
{
    internal sealed class ServiceInfoService : IServiceInfoService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ServiceInfoService(IRepositoryManager repository,IMapper mapper) {
            _repository = repository;
            _mapper    = mapper;
        }

        public IEnumerable<ServiceInfo> GetAllServiceInfo(bool trackChanges)
        {
            

                    try
                    {
                        var serviceInfoEntities = _repository.ServiceInfo.GetAllServiceInfo(trackChanges);
                        var serviceInfo = _mapper.Map<IEnumerable<ServiceInfo>>(serviceInfoEntities);

                        return serviceInfo;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

        }

        public IEnumerable<ServiceInfo> GetByType(serviceType serviceType, bool trackChanges)
        {
            try
            {
                var serviceInfoEntities = _repository.ServiceInfo.GetByType(serviceType,trackChanges);
                var serviceInfo = _mapper.Map<IEnumerable<ServiceInfo>>(serviceInfoEntities);

                return serviceInfo;
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        public    ResponseMessage DeleteService(ServiceId request,bool trackChanges)
        {
            try
            {
                var service = _repository.ServiceInfo.GetById(request,trackChanges);
                if(service is not null)
                {
                    _repository.ServiceInfo.DeleteService(service,trackChanges);
                    _repository.Save();
                    return new ResponseMessage{Message = ResponseEnum.Successful};
                }
                else   return new ResponseMessage{Message = ResponseEnum.Failed};

            }
            catch (Exception ex)
            {
                return new ResponseMessage{Message = ResponseEnum.Failed};
            }
        }

        public ResponseMessage UpdateService(ServiceId request, bool trackChanges)
        {
            try
            {
                Console.WriteLine(request);
                var service = _repository.ServiceInfo.GetById(request,trackChanges);
                Console.WriteLine(service);
                if(service is not null)
                {
                    service.Timestamp = DateTime.Now;
                    _repository.ServiceInfo.UpdateService(service,trackChanges);
                    _repository.Save();
                    return new ResponseMessage{Message = ResponseEnum.Successful};
                }
                else   return new ResponseMessage{Message = ResponseEnum.Failed};

            }
            catch (Exception ex)
            {
                return new ResponseMessage{Message = ResponseEnum.Failed};
            }
        }

       public ResponseMessage RegisterService(ServiceInfo request,bool trackChanges)
       {
           var serviceRequestId = new ServiceId{Id = request.Id};
           var service = _repository.ServiceInfo.GetById(serviceRequestId,trackChanges);
           if (service != null)
               return new ResponseMessage{Message = ResponseEnum.Failed};

           var serviceInfo = _mapper.Map<ServiceInfoEntity>(request);

           serviceInfo.Timestamp = DateTime.Now;
           _repository.ServiceInfo.RegisterService(serviceInfo,trackChanges);
           _repository.Save();
           return new ResponseMessage{Message = ResponseEnum.Successful};
       }
    }
}
