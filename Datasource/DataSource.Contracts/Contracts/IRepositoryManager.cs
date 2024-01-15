namespace DataSource.Contracts;

public interface IRepositoryManager
{
    IDatasourceRepository DatasourceRepository { get; }

}