using Domain.common;

namespace Domain.session;

public record SessionId(Guid Value) : EntityId
{
    public static SessionId Generate() => new(Guid.NewGuid());
    
    public static SessionId fromString(string id) => new(Guid.Parse(id));
}