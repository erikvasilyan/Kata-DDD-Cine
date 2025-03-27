using Domain.customer;

namespace Domain.seat;

public record ReservedSeatDto(SeatId SeatId, CustomerId AssignedTo) : SeatDto;