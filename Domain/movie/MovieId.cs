using Domain.common;

namespace Domain.movie;

public record MovieId(Guid Value) : EntityId
{
    public static MovieId Generate() => new(Guid.NewGuid());

    public static MovieId fromString(string requestMovieId) => new(Guid.Parse(requestMovieId));
}