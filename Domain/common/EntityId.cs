namespace Domain.common;

public interface EntityId : ValueObject
{
    public Guid Value { get; init; }
}