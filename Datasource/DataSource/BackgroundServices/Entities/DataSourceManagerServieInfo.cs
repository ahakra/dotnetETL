using DataSource.BackgroundServices.Contracts;
using ServiceMesh;
namespace DataSource.BackgroundServices.Entities;

public class DataSourceManagerInitializer:IDatasourceInitiliazer {
    public string GrpcURl {get;set;}
    public ServiceInfo ServiceInfo {get;set;}
    public ServiceAdapter ServiceAdapter {get;set;}
}