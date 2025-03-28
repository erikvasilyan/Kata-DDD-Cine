using Domain.common;
using Domain.seat;
using Domain.session;

namespace Domain.exceptions;

public class SeatIsAlreadyReservedException(SessionId sessionId, SeatId seatId) : DomainException($"Seat {seatId} is already reserved for session {sessionId}");