using MongoDB.Driver;
using BookApi.Interface;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BookApi.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task Add(TEntity obj)
        {
            await DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.Find(new BsonDocument()).ToListAsync();
        }

        public virtual async Task<bool> Update(TEntity obj)
        {
            var result = await DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj);
            return result.IsAcknowledged ? result.IsAcknowledged : false;
        }

        public virtual async Task<bool> Remove(string id)
        {
            var result = await DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return result.DeletedCount > 0 ? true : false;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
        public long GetCollectionCount()
        {
            return DbSet.CountDocuments(Builders<TEntity>.Filter.Empty);
        }
    }
}
