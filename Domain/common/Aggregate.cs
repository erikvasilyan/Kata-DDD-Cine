namespace Domain.common;

public abstract class Aggregate<T>(T id) : Entity<T>(id) where T : EntityId
{
    public new T Id { get; init; } = id;
}