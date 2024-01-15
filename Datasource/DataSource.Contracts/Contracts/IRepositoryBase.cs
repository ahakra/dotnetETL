namespace DataSource.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface IRepositoryBase<T> {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(ObjectId id);
    Task<T> Insert(T entity);
    Task Update(ObjectId id, T entity);
    Task<int> Delete(ObjectId id);
}