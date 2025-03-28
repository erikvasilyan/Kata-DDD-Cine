using Domain.customer;
using Domain.seat;
using Domain.session;

namespace Domain.reservation;

public record SeatReservationDto(SeatReservationId Id, SessionId SessionId, SeatId SeatId, CustomerId? ReservedBy);