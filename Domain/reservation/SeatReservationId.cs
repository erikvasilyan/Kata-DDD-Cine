using Domain.common;

namespace Domain.reservation;

public record SeatReservationId(Guid Value) : EntityId
{
    public static SeatReservationId Generate() => new(Guid.NewGuid());
}