using Domain.common;

namespace Domain.sala;

public record SalaId(Guid Value) : EntityId
{
    public static SalaId Generate() => new(Guid.NewGuid());
}