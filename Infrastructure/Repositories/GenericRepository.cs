using Application.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        // Constructor to initialize the MongoDB collection
        protected GenericRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        // Get all documents in the collection
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        // Get paginated documents
        public async Task<IEnumerable<T>> GetAllPaginator(int pageNr, int pageSize)
        {
            return await _collection.Find(_ => true)
                                   .Skip((pageNr - 1) * pageSize)
                                   .Limit(pageSize)
                                   .ToListAsync();
        }

        // Get a document by its ID (assuming the ID is a string)
        public async Task<T?> GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        // Create a new document
        public async Task<T> Create(T newObject)
        {
            await _collection.InsertOneAsync(newObject);
            return newObject;
        }

        // Update a document by its ID
        public async Task<T> Update(string id, T modifiedObject)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, modifiedObject);
            return modifiedObject;
        }

        // Delete a document by its ID
        public async Task Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}