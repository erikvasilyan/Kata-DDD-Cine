using Domain.common;
using Domain.customer;
using Domain.exceptions;
using Domain.seat;

namespace Domain.auditorium;

public class Auditorium : Aggregate<AuditoriumId>
{
    public List<Seat> Seats { get; init; }
    public int SeatsCount { get; init; }

    private Auditorium(AuditoriumId id, int seatsCount) : base(id)
    {
        Id = id;
        SeatsCount = seatsCount;
        Seats = AllocateSeats();
    }
    
    public static Auditorium Create(AuditoriumId id, int seatsCount) => new(id, seatsCount);

    private List<Seat> AllocateSeats()
    {
        var seats = new List<Seat>();
        for (var i = 1; i <= SeatsCount; i++)
        {
            var seatId = new SeatId(Guid.NewGuid());
            var availableSeat = AvailableSeat.Create(seatId, new SeatNumber(i));
            seats.Add(availableSeat);
        }
        
        return seats;
    }
    
    public ReservedSeat ReserveSeat(CustomerId customerId, SeatNumber seatNumber)
    {
        var availableSeat = Seats.OfType<AvailableSeat>().FirstOrDefault(seat => seat.Number == seatNumber) 
                             ?? throw new SeatIsBusyException(seatNumber);
        var reservedSeat = availableSeat.Reserve(customerId);
        Seats[Seats.IndexOf(availableSeat)] = reservedSeat;
        
        return reservedSeat;
    }
}