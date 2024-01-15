using MongoDB.Bson;
using DataSource.Contracts;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

public class MongoRepositoryBase<T> : IRepositoryBase<T>
    {
        protected IMongoCollection<T> _collection;
      
       
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Update(ObjectId id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task Delete(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
    
