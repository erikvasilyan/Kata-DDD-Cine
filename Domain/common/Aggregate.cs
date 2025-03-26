namespace Domain.common;

public abstract class Aggregate<T>(T id) where T : EntityId 
{
    public T Id { get; init; } = id;
}