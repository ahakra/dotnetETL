namespace ServiceMesh.Contracts
{
    public interface IRepositoryManager
    {
       IServiceInfoRepository ServiceInfo { get; }
      

        void Save();
    }
}
