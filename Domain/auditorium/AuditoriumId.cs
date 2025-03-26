using Domain.common;

namespace Domain.auditorium;

public record AuditoriumId(Guid Value) : EntityId
{
    public static AuditoriumId Generate() => new(Guid.NewGuid());
}