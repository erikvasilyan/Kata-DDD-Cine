using Domain.common;

namespace Domain.seat;

public abstract class ReservationSeat : Entity<SeatId>
{
    protected ReservationSeat(SeatId id) : base(id) { }
    
    public abstract SeatDto ToDto();
}