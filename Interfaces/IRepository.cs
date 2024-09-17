namespace BookApi.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Update(TEntity obj);
        Task<bool> Remove(string id);
        long GetCollectionCount();
        Task<List<TEntity>> QueryCollectionAsync(TEntity obj,Dictionary<string, object> filterParameters);
    }
}