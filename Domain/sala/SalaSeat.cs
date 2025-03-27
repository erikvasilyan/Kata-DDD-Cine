using Domain.common;
using Domain.seat;

namespace Domain.sala;

public class SalaSeat : Entity<SeatId>
{
    public SeatNumber Number { get; init; }
    
    private SalaSeat(SeatId id, SeatNumber number) : base(id)
    {
        Number = number;
    }
    
    public static SalaSeat Create(SeatId id, SeatNumber number) => new(id, number);
}