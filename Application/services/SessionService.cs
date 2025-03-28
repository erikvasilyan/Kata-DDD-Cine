using Domain.common;
using Domain.movie;
using Domain.repositories;
using Domain.sala;
using Domain.session;

namespace Application.services;

public class SessionService
{
    private SessionRepository SessionRepository;
    private SeatReservationRepository SeatReservationRepository;
    private SalaRepository SalaRepository;
    private MovieRepository MovieRepository;
    
    public async void StartMovieSession(string requestMovieId, string requestSalaId, DateTime requestStartTime)
    {
        var sessionId = SessionId.Generate();
        var movieId = MovieId.fromString(requestMovieId);
        var salaId = SalaId.fromString(requestSalaId);
        var startDateTime = CDateTime.from(requestStartTime);
        
        var movie = await MovieRepository.GetById(movieId);
        var sala = await SalaRepository.GetById(salaId);

        var session = Session.Create(sessionId, movie.Id, sala.Id, startDateTime);
        var seats = sala.GetAllSeatsIds();
        var seatReservations = session.StartBooking(seats);
        
        await SessionRepository.Save(session);
        await SeatReservationRepository.BulkSave(seatReservations);
    }
}