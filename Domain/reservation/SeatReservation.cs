using Domain.common;
using Domain.customer;
using Domain.exceptions;
using Domain.seat;
using Domain.session;

namespace Domain.reservation;

public class SeatReservation : Aggregate<SeatReservationId>
{
    public SessionId SessionId { get; init; }
    public SeatId SeatId { get; init; }
    public CustomerId? ReservedBy { get; private set; }

    private SeatReservation(SeatReservationId id, SessionId sessionId, SeatId seatId) : base(id)
    {
        SessionId = sessionId;
        SeatId = seatId;
    }
    
    public static SeatReservation Create(SeatReservationId id, SessionId sessionId, SeatId seatId) 
        => new(id, sessionId, seatId);

    public SeatReservation Reserve(CustomerId customerId)
    {
        if (IsReserved())
        {
            throw new SeatIsAlreadyReservedException(SessionId, SeatId);
        }
        
        ReservedBy = customerId;
        
        return this;
    }
    
    public bool IsReserved() => ReservedBy != null;

    public SeatReservationDto ToDto() => new(Id, SessionId, SeatId, ReservedBy);
}