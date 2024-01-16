using ServiceMesh;

namespace DataSource.BackgroundServices.Contracts;

public interface IDatasourceInitiliazer {
    public string GrpcURl {get;set;}
    public ServiceInfo ServiceInfo {get;set;}
    public ServiceAdapter ServiceAdapter {get;set;}
}