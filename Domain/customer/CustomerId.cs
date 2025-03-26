using Domain.common;

namespace Domain.customer;

public record CustomerId(Guid Value) : EntityId
{
    public static CustomerId Generate() => new(Guid.NewGuid());
}