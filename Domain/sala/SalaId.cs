using Domain.common;

namespace Domain.sala;

public record SalaId(Guid Value) : EntityId
{
    public static SalaId Generate() => new(Guid.NewGuid());

    public static SalaId fromString(string requestSalaId) => new(Guid.Parse(requestSalaId));
}