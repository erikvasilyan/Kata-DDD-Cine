using Domain.common;

namespace Domain.repositories;

public interface BaseRepository<T, in K> where T : Entity<K> where K : EntityId
{
    public Task<T> GetById(K id);
    public Task<List<T>>GetAll();
    public Task<T> Save(T entity);
    public Task<List<T>> BulkSave(List<T> entities);
    public Task<T> Update(T entity);
}