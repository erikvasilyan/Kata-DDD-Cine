namespace Domain.common;

public abstract class Entity<T>(T id) where T : EntityId 
{
    public T Id { get; init; } = id;
}