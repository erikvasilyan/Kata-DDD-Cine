using Domain.common;
using Domain.seat;

namespace Domain.exceptions;

public class SeatIsBusyException(SeatId seatId) : DomainException($"Seat {seatId} is already busy");