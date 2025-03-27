using Domain.common;
using Domain.sala;

namespace Domain.exceptions;

public class SeatNotFoundException(SalaId salaId, SeatNumber seatNumber) : DomainException($"Seat {seatNumber} not found in sala {salaId}");