using Domain.common;

namespace Domain.seat;

public record SeatId(Guid Value) : EntityId
{
    public static SeatId Generate() => new(Guid.NewGuid());
}