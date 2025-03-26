using Domain.customer;

namespace Domain.seat;

public record ReservedSeatDto(SeatId SeatId, SeatNumber SeatNumber, CustomerId AssignedTo) : SeatDto;