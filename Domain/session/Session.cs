using Domain.auditorium;
using Domain.common;
using Domain.movie;

namespace Domain.session;

public class Session : Entity<SessionId>
{
    public MovieId MovieId { get; init; }
    public AuditoriumId AuditoriumId { get; init; }
    public CDateTime StartDateTime { get; init; }
    
    private Session(SessionId id, MovieId movieId, AuditoriumId auditoriumId, CDateTime startDateTime) : base(id)
    {
        MovieId = movieId;
        AuditoriumId = auditoriumId;
        StartDateTime = startDateTime;
    }
    
    public static Session Create(SessionId id, MovieId movieId, AuditoriumId auditoriumId, CDateTime startDateTime) 
        => new(id, movieId, auditoriumId, startDateTime);
}