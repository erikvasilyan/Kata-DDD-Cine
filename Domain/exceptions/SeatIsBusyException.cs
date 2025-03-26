using Domain.common;
using Domain.seat;

namespace Domain.exceptions;

public class SeatIsBusyException(SeatNumber seatNumber) : DomainException($"Seat {seatNumber.toInt()} is already busy");