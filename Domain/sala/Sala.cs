using Domain.common;
using Domain.exceptions;
using Domain.seat;

namespace Domain.sala;

public class Sala : Entity<SalaId>
{
    public List<SalaSeat> Seats { get; init; }
    public int SeatsCount { get; init; }

    private Sala(SalaId id, int seatsCount) : base(id)
    {
        Id = id;
        SeatsCount = seatsCount;
        Seats = AllocateSeats();
    }
    
    public static Sala Create(SalaId id, int seatsCount) => new(id, seatsCount);

    private List<SalaSeat> AllocateSeats()
    {
        var seats = new List<SalaSeat>();
        for (var i = 1; i <= SeatsCount; i++)
        {
            var seatId = SeatId.Generate();
            var seat = SalaSeat.Create(seatId, new SeatNumber(i));
            seats.Add(seat);
        }
        
        return seats;
    }
    
    public SalaSeat getSeat(SeatNumber seatNumber)
    {
        return Seats.FirstOrDefault(seat => seat.Number == seatNumber) 
               ?? throw new SeatNotFoundException(Id, seatNumber);
    }
}