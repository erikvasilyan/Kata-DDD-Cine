using Domain.common;

namespace Domain.repositories;

public interface BaseRepository<T, in K> where T : Entity<K> where K : EntityId
{
    public T GetById(K id);
    public List<T> GetAll();
    public void Save(T entity);
}