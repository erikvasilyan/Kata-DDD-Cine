using Domain.common;

namespace Domain.seat;

public class Seat : Entity<SeatId>
{
    public SeatNumber Number { get; init; }
    
    private Seat(SeatId id, SeatNumber number) : base(id)
    {
        Number = number;
    }
    
    public static Seat Create(SeatId id, SeatNumber number) => new(id, number);
}