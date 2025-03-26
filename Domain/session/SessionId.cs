using Domain.common;

namespace Domain.session;

public record SessionId(Guid Value) : EntityId;