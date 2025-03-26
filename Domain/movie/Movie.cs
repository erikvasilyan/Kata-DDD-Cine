using Domain.common;

namespace Domain.movie;

public class Movie : Entity<MovieId>
{
    private Movie(MovieId id) : base(id) { }
    
    public static Movie Create(MovieId id) => new Movie(id);
}