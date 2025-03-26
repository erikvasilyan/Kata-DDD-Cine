using Domain.common;

namespace Domain.seat;

public abstract class Seat : Entity<SeatId>
{
    public SeatNumber Number { get; init; }
    
    protected Seat(SeatId id, SeatNumber number) : base(id)
    {
        Number = number;
    }

    public abstract SeatDto ToDto();
}