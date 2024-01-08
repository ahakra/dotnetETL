using Grpc.Core;
using ServiceMesh;
using ServiceMesh.Contracts.Service;

namespace ServiceMesh.GrpcServices
{
    public class ServiceRegistererService : ServiceRegisterer.ServiceRegistererBase
    {
        private readonly IServiceManager _service;
       
        public ServiceRegistererService(IServiceManager service) => _service = service;
       
        public override Task<ResponseMessage> RegisterService(ServiceInfo request, ServerCallContext context)
        {
            
            return Task.FromResult(_service.ServiceInfoService.RegisterService(request,false));

        }

        public override Task<ResponseMessage> UpdateService(ServiceId request, ServerCallContext context)
        {

            return Task.FromResult(_service.ServiceInfoService.UpdateService(request,false));

        }

        public override Task<ResponseMessage> DeleteService(ServiceId request, ServerCallContext context)
        {

            return  Task.FromResult(_service.ServiceInfoService.DeleteService(request,false));

        }

        public override Task<ServicesAvailable> GetAll(EmptyMessage request, ServerCallContext context)
        {
                try
                {
                        var serviceInfod =  _service.ServiceInfoService.GetAllServiceInfo(false);
                        var ServicesAvailableGrpc = new ServicesAvailable{Services = { serviceInfod }};
                        return Task.FromResult(ServicesAvailableGrpc);

                }
                catch(Exception e)
                {

                        return Task.FromResult(new ServicesAvailable { });
                }

        }

        public override Task<ServicesAvailable> GetByType(serviceType request, ServerCallContext context)
        {
                try
                {
                        var serviceInfod =  _service.ServiceInfoService.GetByType(request,false);
                        var ServicesAvailableGrpc = new ServicesAvailable{Services = { serviceInfod }};
                        return Task.FromResult(ServicesAvailableGrpc);
                }
                catch(Exception e)
                {

                        return Task.FromResult(new ServicesAvailable { });
                }
        }

    }
}