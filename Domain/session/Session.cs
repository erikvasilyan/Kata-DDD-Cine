using Domain.common;
using Domain.customer;
using Domain.exceptions;
using Domain.movie;
using Domain.sala;
using Domain.seat;

namespace Domain.session;

public class Session : Entity<SessionId>
{
    public MovieId MovieId { get; init; }
    public SalaId SalaId { get; init; }
    public CDateTime StartDateTime { get; init; }
    public List<ReservationSeat> Seats { get; init; }

    private Session(SessionId id, MovieId movieId, SalaId salaId, CDateTime startDateTime, List<SalaSeat> seats) : base(id)
    {
        MovieId = movieId;
        SalaId = salaId;
        StartDateTime = startDateTime;
        Seats = CreateAvailableSeats(seats);
    }

    private List<ReservationSeat> CreateAvailableSeats(List<SalaSeat> salaSeats)
    {
        return salaSeats.Select(seat => AvailableSeat.Create(seat.Id)).Cast<ReservationSeat>().ToList();
    }

    public static Session Create(SessionId id, MovieId movieId, SalaId salaId, CDateTime startDateTime, List<SalaSeat> seats) 
        => new(id, movieId, salaId, startDateTime, seats);
    
    public ReservedSeat ReserveSeat(CustomerId customerId, SeatId seatId)
    {
        var availableSeat = Seats.OfType<AvailableSeat>().FirstOrDefault(seat => seat.Id == seatId) 
                             ?? throw new SeatIsBusyException(seatId);
        
        var reservedSeat = availableSeat.Reserve(customerId);
        Seats[Seats.IndexOf(availableSeat)] = reservedSeat;
        
        return reservedSeat;
    }
}