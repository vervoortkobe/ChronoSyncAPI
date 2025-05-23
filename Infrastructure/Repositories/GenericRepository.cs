﻿using System.Linq.Expressions;
using Application.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly IMongoCollection<T> collection;

    protected GenericRepository(IMongoDatabase database, string collectionName)
    {
        collection = database.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> GetAll(int pageNr, int pageSize)
    {
        return await collection.Find(_ => true)
            .Skip((pageNr - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task<T?> GetById(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        return await collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await collection.Find(predicate).ToListAsync();
    }

    public async Task<T> Create(T newObject)
    {
        await collection.InsertOneAsync(newObject);
        return newObject;
    }

    public async Task<T> Update(string id, T modifiedObject)
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        await collection.ReplaceOneAsync(filter, modifiedObject);
        return modifiedObject;
    }

    public async Task Delete(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
        await collection.DeleteOneAsync(filter);
    }
}