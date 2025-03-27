using Domain.common;

namespace Domain.sala;

public record SeatNumber(int Value) : ValueObject
{
    public int ToInt() => Value;
}