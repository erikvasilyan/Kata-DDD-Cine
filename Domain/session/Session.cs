using Domain.common;
using Domain.movie;
using Domain.reservation;
using Domain.sala;
using Domain.seat;

namespace Domain.session;

public class Session : Entity<SessionId>
{
    public MovieId MovieId { get; init; }
    public SalaId SalaId { get; init; }
    public CDateTime StartDateTime { get; init; }

    private Session(SessionId id, MovieId movieId, SalaId salaId, CDateTime startDateTime) : base(id)
    {
        MovieId = movieId;
        SalaId = salaId;
        StartDateTime = startDateTime;
    }
    
    public static Session Create(SessionId id, MovieId movieId, SalaId salaId, CDateTime startDateTime) 
        => new(id, movieId, salaId, startDateTime);
    
    public List<SeatReservation> StartBooking(List<SeatId> seats)
    {
        var reservations = new List<SeatReservation>();
        foreach (var seatId in seats)
        {
            var seatReservationId = SeatReservationId.Generate();
            var seatReservation = SeatReservation.Create(seatReservationId, Id, seatId);
            reservations.Add(seatReservation);
        }
        
        return reservations;
    }
}