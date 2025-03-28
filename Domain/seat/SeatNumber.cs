using Domain.common;

namespace Domain.seat;

public record SeatNumber(int Value) : ValueObject
{
    public int ToInt() => Value;
}